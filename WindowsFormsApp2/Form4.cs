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
    public partial class Form4 : Form
    {
        int cubukHızı=8;
        int yercekimi = 15;
        int skor = 0;

        

        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void GameTimer(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button3.Visible = false;
            pictureBox2_spaceship.Top += yercekimi;
            pictureBox1_meteor1.Left -= cubukHızı;
            pictureBox3_meteor2.Left -= cubukHızı;
            label1.Text = "SCORE: " + skor;

            if (pictureBox1_meteor1.Left < -150)
            {
                pictureBox1_meteor1.Left = 800;
                skor++;
            }
            if (pictureBox3_meteor2.Left < -180)
            {
                pictureBox3_meteor2.Left = 950;
                skor++;
            }
            if (pictureBox2_spaceship.Bounds.IntersectsWith(pictureBox1_meteor1.Bounds) ||
                pictureBox2_spaceship.Bounds.IntersectsWith(pictureBox3_meteor2.Bounds) ||
                pictureBox2_spaceship.Bounds.IntersectsWith(pictureBox_ground.Bounds) || pictureBox2_spaceship.Top<35)
            {
                OyunSonu();
            }
           
        }
        public void OyunSonu()
        {
            TimerForGame.Stop();
            label1.Text = "Game Over!!! Your Score: "+skor;
            button1.Enabled = true;
            button1.Visible = true;
            button2.Visible = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button3.Visible = true;

            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
            baglanti.Open();
            OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
            giris.Parameters.AddWithValue("kullaniciadi", Form1.kulad);
            OleDbDataReader oku = giris.ExecuteReader();
            if (oku.Read())
            {
                if (Convert.ToInt32(oku["oyun1"].ToString()) < skor)
                {
                    OleDbCommand komut = new OleDbCommand("update aaaaa set oyun1='" + skor + "' where kullaniciadi='" + Form1.kulad + "'", baglanti); //oku["sifre"].ToString()
                    komut.ExecuteNonQuery();
                }
            }
            baglanti.Close();
                
        }

        private void Game_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                yercekimi = -8;
            }
        }

        private void Game_up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                yercekimi = 8;
            }
        }

        private void pictureBox1_meteor1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can control the spaceship with the space key. Try not to hit meteors.");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        int mouse_x;
        int mouse_y;

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
    }
}
