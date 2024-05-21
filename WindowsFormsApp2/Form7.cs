using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Media;

namespace WindowsFormsApp2
{
    
    public partial class Form7 : Form
    {
        int sutun = 50, satır = 25;
        int skor = 0;
        int dx = 0, dy = 0, front = 0, back = 0;
        Piece[] yılan = new Piece[1250];
        List<int> available = new List<int>();
        bool[,] ziyaret;
        Random rastgele = new Random();

        Timer zamanlayıcı = new Timer();

        public Form7()
        {
            InitializeComponent();
            intial();
            launchTimer();
 
        }

        private void launchTimer()
        {
            zamanlayıcı.Interval = 50;
            zamanlayıcı.Tick += move;
            zamanlayıcı.Start();
        }

        private void move(object sender, EventArgs e)
        {
            int x = yılan[front].Location.X, y = yılan[front].Location.Y;
            if (dx == 0 && dy == 0) return;
            if (oyunbitti(x + dx, y + dy))
            {
                zamanlayıcı.Stop();
                MessageBox.Show("Game Over!!");
                button1.Enabled = true;
                button1.Visible = true;
                button2.Enabled = true;
                button2.Visible = true;
                button3.Enabled = true;
                button3.Visible = true;
                return;
            }
            if (YemekYeme(x + dx, y + dy))
            {
                skor += 1;
                lblskor.Text = "Score: " + skor.ToString();
                if (carpisma((y + dy) / 20, (x + dx) / 20)) return;
                Piece yılanınkendisi = new Piece(x+dx, y+dy);
                front = (front - 1 + 1250) % 1250;
                yılan[front] = yılanınkendisi;
                ziyaret[yılanınkendisi.Location.Y / 20, yılanınkendisi.Location.X / 20] = true;
                Controls.Add(yılanınkendisi);
                rastgeleyemek();
            }
            else
            {
                if (carpisma((y + dy) / 20, (x + dx) / 20)) return;
                ziyaret[yılan[back].Location.Y / 20, yılan[back].Location.X / 20] = false;
                front = (front - 1 + 1250) % 1250;
                yılan[front] = yılan[back];
                yılan[front].Location = new Point(x + dx, y + dy);
                back = (back - 1 + 1250) % 1250;
                ziyaret[(y + dy) / 20, (x + dx) / 20] = true;
            }
        }

        private void rastgeleyemek()
        {
            available.Clear();
            for (int i = 2; i < satır; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    if (!ziyaret[i, j])
                    {
                        available.Add(i * sutun + j);
                    }
                }
            }
            int idx = rastgele.Next(available.Count) % available.Count;
            lblyemek.Left = (available[idx] * 20) % Width;
            lblyemek.Top = (available[idx] * 20) / Width * 20;
        }

        private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            dx = dy = 0;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    dx = 20;
                    break;
                case Keys.Left:
                    dx = -20;
                    break;
                case Keys.Up:
                    dy = -20;
                    break;
                case Keys.Down:
                    dy = 20;
                    break;

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In the begining green square is snake and midnight blue square is food. You can control the snake with the arrow keys. Try not to hit yourself and walls.");
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool carpisma(int x, int y)
        {
            if (ziyaret[x, y])
            {
                zamanlayıcı.Stop();
                MessageBox.Show("The Snake Hits Itself. Game over!!");
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
                baglanti.Open();
                OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
                giris.Parameters.AddWithValue("kullaniciadi", Form1.kulad);
                OleDbDataReader oku = giris.ExecuteReader();
                if (oku.Read())
                {
                    if (Convert.ToInt32(oku["oyun4"].ToString()) < skor)
                    {
                        OleDbCommand komut = new OleDbCommand("update aaaaa set oyun4='" + skor + "' where kullaniciadi='" + Form1.kulad + "'", baglanti); //oku["sifre"].ToString()
                        komut.ExecuteNonQuery();
                    }
                }
                baglanti.Close();
                button1.Enabled = true;
                button1.Visible = true;
                button2.Enabled = true;
                button2.Visible = true;
                button3.Enabled = true;
                button3.Visible = true;
                return true;
            }

            return false;
        }

        private bool YemekYeme(int x, int y)
        {
            return x == lblyemek.Location.X && y == lblyemek.Location.Y;
        }

        private bool oyunbitti(int x, int y)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
            baglanti.Open();
            OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
            giris.Parameters.AddWithValue("kullaniciadi", Form1.kulad);
            OleDbDataReader oku = giris.ExecuteReader();
            if (oku.Read())
            {
                if (Convert.ToInt32(oku["oyun4"].ToString()) < skor)
                {
                    OleDbCommand komut = new OleDbCommand("update aaaaa set oyun4='" + skor + "' where kullaniciadi='" + Form1.kulad + "'", baglanti); //oku["sifre"].ToString()
                    komut.ExecuteNonQuery();
                }
            }
            baglanti.Close();

            return x < 0 || y < 0 || x > 980 || y > 480;
        }

        private void intial()
        {
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button3.Enabled = false;
            button3.Visible = false;

            ziyaret = new bool[satır, sutun];
            Piece yılanınkendisi = new Piece((rastgele.Next() % sutun)*20,(rastgele.Next()% satır)*20);
            lblyemek.Location=new Point((rastgele.Next() % sutun) * 20, (rastgele.Next() % satır) * 20);
            for (int i = 2; i < satır; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    ziyaret[i, j] = false;
                    available.Add(i * sutun + j);
                }
                ziyaret[yılanınkendisi.Location.Y / 20, yılanınkendisi.Location.X / 20] = true;
                available.Remove(yılanınkendisi.Location.Y / 20 * sutun + yılanınkendisi.Location.X / 20);
                Controls.Add(yılanınkendisi);
                yılan[front] = yılanınkendisi;
            }
        }
    }
}
