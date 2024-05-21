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
    public partial class Form8 : Form
    {
        bool goLeft, goRight;

        int speed = 8;
        int score = 0;
        int missed = 0;


        Random randX = new Random();
        Random randY = new Random();

        PictureBox splash = new PictureBox();
        public Form8()
        {
            InitializeComponent();
            button1.Enabled = false;
            button1.Visible = false;
            button2.Enabled = false;
            button2.Visible = false;
            button3.Enabled = false;
            button3.Visible = false;


            RestartGame();
        }
        bool move;
        int mouse_x;
        int mouse_y;

       

        private void mainGameTimer(object sender, EventArgs e)
        {
            txtScore.Text = "Saved: " + score;
            txtMiss.Text = "Missed: " + missed;

            if(goLeft == true && player.Left >0)
            {
                player.Left -= 12;
                player.Image = Properties.Resources.elon_musk_ilk;
            }
            if(goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += 12;
                player.Image = Properties.Resources.elon_musk_ilk;
            }

            foreach (Control x in this.Controls)
            {

                if(x is PictureBox && (string)x.Tag == "yumurta")
                {
                    x.Top += speed;

                    if (x.Top + x.Height > this.ClientSize.Height)
                    {
                        splash.Image = Properties.Resources.splash;
                        splash.Location = x.Location;
                        splash.Height = 60;
                        splash.Width = 60;
                        splash.BackColor = Color.Transparent;

                        this.Controls.Add(splash);


                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randX.Next(5, this.ClientSize.Width - x.Width);
                        missed += 1;
                        player.Image = Properties.Resources.hmhd28rzrly01;

                    }

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.Top = randY.Next(80, 300) * -1;
                        x.Left = randX.Next(5, this.ClientSize.Width - x.Width);
                        score += 1;
                    }
                }

            }

            if(score > 10)
            {
                speed = 12;
            }

            if (missed > 5)
            {
                gameTimer.Stop();
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
                baglanti.Open();
                OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
                giris.Parameters.AddWithValue("kullaniciadi", Form1.kulad);
                OleDbDataReader oku = giris.ExecuteReader();
                if (oku.Read())
                {
                    if (Convert.ToInt32(oku["oyun5"].ToString()) < score)
                    {
                        OleDbCommand komut = new OleDbCommand("update aaaaa set oyun5='" + score + "' where kullaniciadi='" + Form1.kulad + "'", baglanti); //oku["sifre"].ToString()
                        komut.ExecuteNonQuery();
                    }
                }
                baglanti.Close();
                MessageBox.Show("Game Over!" + Environment.NewLine + "We've lost coins" + Environment.NewLine + "Click ok to retry");
                button1.Enabled = true;
                button1.Visible = true;
                button2.Enabled = true;
                button2.Visible = true;
                button3.Enabled = true;
                button3.Visible = true;
                
            }



        }

        private void Form8_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void Form8_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
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
            MessageBox.Show("You can help to Elon to collect all the coins. Use arrow keys to control Elon. Try not to miss more than 5 coins.");        
        }

       

        private void RestartGame()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "yumurta")
                {
                    x.Top = randY.Next(80, 300) * -1;
                    x.Left = randX.Next(5, this.ClientSize.Width - x.Width);
                }
            }

            player.Left = this.ClientSize.Width / 2;
            player.Image = Properties.Resources.elon_musk_ilk;

            score = 0;
            missed = 0;
            speed = 8;

            goLeft = false;
            goRight = false;

            gameTimer.Start();

        
        }
    }
}
