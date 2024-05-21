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
    public partial class Form6 : Form
    {

        bool yukari, asagi, sol, sag, oyunbitti;
        int skor, oyuncuhizi, kirmiziHayaletHiz, sariHayaletHiz, pembeHayaletX, pembeHayaletY;
        
        bool move;
        int mouse_x;
        int mouse_y;


        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have to collect all the golds without hitting the walls and getting eaten by ghosts.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public Form6()
        {
            InitializeComponent();
            resetgame();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                yukari = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                asagi = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                sol = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                sag = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                yukari = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                asagi = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                sol = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                sag = false;
            }

            if (e.KeyCode == Keys.Enter && oyunbitti == true)
            {
                resetgame();
            }
        }

        private void anaZamanlayici(object sender, EventArgs e)
        {
            txtscore.Text = "Score: " + skor;

            if (sol == true)
            {
                pacman.Left -= oyuncuhizi;
                pacman.Image = Properties.Resources.left;
            }

            if (sag == true)
            {
                pacman.Left += oyuncuhizi;
                pacman.Image = Properties.Resources.right;
            }

            if (asagi == true)
            {
                pacman.Top += oyuncuhizi;
                pacman.Image = Properties.Resources.down;
            }

            if (yukari == true)
            {
                pacman.Top -= oyuncuhizi;
                pacman.Image = Properties.Resources.Up;
            }



            if (pacman.Left < -10)
            {
                pacman.Left = 680;
            }

            if (pacman.Left > 680)
            {
                pacman.Left = -10;
            }

            if (pacman.Top < 20)
            {
                pacman.Top = 550;
            }

            if (pacman.Top > 550)
            {
                pacman.Top = 20;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "para" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            skor += 1;
                            x.Visible = false;
                        }

                    }

                    if ((string)x.Tag == "duvar")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameover("!!YOU LOSE!!");
                        }

                        if (pembeHayalet.Bounds.IntersectsWith(x.Bounds))
                        {
                            pembeHayaletX = -pembeHayaletX;
                        }
                    }

                    if ((string)x.Tag == "hayalet")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameover("!!YOU LOSE!!");
                        }
                    }
                }
            }

            kirmiziHayalet.Left += kirmiziHayaletHiz;

            if (kirmiziHayalet.Bounds.IntersectsWith(pictureBox48.Bounds) || kirmiziHayalet.Bounds.IntersectsWith(pictureBox49.Bounds))
            {
                kirmiziHayaletHiz = -kirmiziHayaletHiz;
            }

            sariHayalet.Left -= sariHayaletHiz;

            if (sariHayalet.Bounds.IntersectsWith(pictureBox3.Bounds) || sariHayalet.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                sariHayaletHiz = -sariHayaletHiz;
            }

            pembeHayalet.Left -= pembeHayaletX;
            pembeHayalet.Top -= pembeHayaletY;

            if (pembeHayalet.Top < 20 || pembeHayalet.Top > 520)
            {
                pembeHayaletY = -pembeHayaletY;
            }

            if (pembeHayalet.Left < 0 || pembeHayalet.Left > 620)
            {
                pembeHayaletX = -pembeHayaletX;
            }


            if (skor == 60)
            {
                gameover("!!!YOU WIN!!!");
            }
        }
        private void resetgame()
        {


            txtscore.Text = "Score = 0";
            skor = 0;

            kirmiziHayaletHiz = 5;
            sariHayaletHiz = 5;
            pembeHayaletX = 5;
            pembeHayaletY = 5;
            oyuncuhizi = 8;

            button1.Visible = false;
            button1.Enabled = false;
            button2.Visible = false;
            button2.Enabled = false;
            button3.Visible = false;
            button3.Enabled = false;

            oyunbitti = false;

            pacman.Left = 10;
            pacman.Top = 60;

            kirmiziHayalet.Left = 225;
            kirmiziHayalet.Top = 90;

            sariHayalet.Left = 454;
            sariHayalet.Top = 440;

            pembeHayalet.Left = 430;
            pembeHayalet.Top = 304;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            oyunZamanlayici.Start();
        }

        private void gameover(string message)
        {

            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
            baglanti.Open();
            OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
            giris.Parameters.AddWithValue("kullaniciadi", Form1.kulad);
            OleDbDataReader oku = giris.ExecuteReader();
            if (oku.Read())
            {
                if (Convert.ToInt32(oku["oyun3"].ToString()) < skor)
                {
                    OleDbCommand komut = new OleDbCommand("update aaaaa set oyun3='" + skor + "' where kullaniciadi='" + Form1.kulad + "'", baglanti);
                    komut.ExecuteNonQuery();
                }
            }
            baglanti.Close();
            oyunbitti = true;
            oyunZamanlayici.Stop();
            txtscore.Text += "" +  Environment.NewLine + message;
            button1.Visible = true;
            button1.Enabled = true;
            button2.Visible = true;
            button2.Enabled = true;
            button3.Visible = true;
            button3.Enabled = true;
        }
    }
}
