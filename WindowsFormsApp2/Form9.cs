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
    public partial class Form9 : Form
    {
        bool solaGit;
        bool sagaGit;

        int skor;
        int topx;
        int topy;
        int oyuncuHizi;

        Random rastgele = new Random();
        bool move;
        int mouse_x;
        int mouse_y;

        public Form9()
        {
            InitializeComponent();
            button2.Enabled = false;
            button2.Visible = false;
            button3.Enabled = false;
            button3.Visible = false;
            button4.Enabled = false;
            button4.Visible = false;
            oyunKurulma();
        }

        private void oyunKurulma()
        {
            skor = 0;
            topx = 5;
            topy = 5;
            oyuncuHizi = 12;
            txtScore.Text = "score: " + skor;

            zamanlayıcı.Start();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bloklar")
                {
                    x.BackColor = Color.FromArgb(rastgele.Next(256), rastgele.Next(256), rastgele.Next(256));

                }
            }
        }

        private void oyunBitti(string message)
        {
            zamanlayıcı.Stop();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
            baglanti.Open();
            OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
            giris.Parameters.AddWithValue("kullaniciadi", Form1.kulad);
            OleDbDataReader oku = giris.ExecuteReader();
            if (oku.Read())
            {
                if (Convert.ToInt32(oku["oyun6"].ToString()) < skor)
                {
                    OleDbCommand komut = new OleDbCommand("update aaaaa set oyun6='" + skor + "' where kullaniciadi='" + Form1.kulad + "'", baglanti); //oku["sifre"].ToString()
                    komut.ExecuteNonQuery();
                }
            }
            baglanti.Close();
            txtScore.Text = "SCORE: " + skor + " " + message;
            button2.Enabled = true;
            button2.Visible = true;
            button3.Enabled = true;
            button3.Visible = true;
            button4.Enabled = true;
            button4.Visible = true;
        }
        
    
        private void oyunZamanlayıcı(object sender, EventArgs e) //oyuncu hareketi
        {
            txtScore.Text = "score: " + skor;
            if (solaGit == true && oyuncu.Left > 0)
            {
                oyuncu.Left -= oyuncuHizi;
            }
            if (sagaGit == true && oyuncu.Left < 515)
            {
                oyuncu.Left += oyuncuHizi;
            }
            top.Left += topx;
            top.Top += topy;

            if (top.Left < 0 || top.Left > 590) // top hareketi
            {
                topx = -topx;
            }
            if (top.Top < 30)
            {
                topy = -topy;
            }
            if (top.Bounds.IntersectsWith(oyuncu.Bounds)) //topun carpma sonrası hızını random ayarlamak
            {
                topy = rastgele.Next(5, 12) * -1;

                if (topx < 0)
                {
                    topx = rastgele.Next(5, 12);
                }
                else
                {
                    topx = rastgele.Next(5, 12);
                }
            }


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bloklar")
                {
                    if (top.Bounds.IntersectsWith(x.Bounds))
                    {
                        skor += 1;

                        topy = - topy;
                        this.Controls.Remove(x);
                    }
                }
            }

            if (skor==15)
            {
                oyunBitti("kazandın!");
              
                //bitirme mesajı
            }
            if (top.Top>425)
            {
                oyunBitti("kaybettin!");
                //kaybetme mesajı
            }
        }
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                solaGit = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                sagaGit = true;
            }
        }

        private void keyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                solaGit = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                sagaGit = false;
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Close();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Application.Exit();
   
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have to hit the space ball to break the all blocks. Try not to miss the ball.");
        }
    }
}
