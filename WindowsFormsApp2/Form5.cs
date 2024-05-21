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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            basla();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        string[] harfler = { "a", "b", "c", "d", "e", "f", "g", "h", "ı", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        string[] kelimeler = { "mercury", "venus", "earth", "mars", "jupiter", "saturn", "uranus", "neptune", "sun", "galaxy", "meteor", "star", "comet", "planet" };
        int rastgelesayi;
        string[] yazilan_harfler;
        string secilenkelime;
        int kalanhak=10;
        int skor = 0;

        private void basla()
        {
            yazilan_harfler = new string[0];
            panel2.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            label7.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }


        private void kelimesorgulama(string hrf)
        {
            char[] kelimedizisi = secilenkelime.ToCharArray();
            bool dogru = false;
            for (int z = 0; z < kelimedizisi.Length; z++)
            {
                if (kelimedizisi[z].ToString() != "")
                {
                    if (hrf.ToString()==kelimedizisi[z].ToString().ToLower())
                    {
                        dogru = true;
                        label5.Text = label5.Text.Remove(z * 2, 1);
                        label5.Text = label5.Text.Insert(z * 2, hrf.ToString()).ToUpper();
                        skor += 10;
                        label7.Text = "";
                        label7.Text = "SCORE: " + skor;
                    }
                }
            }
            
            if (!dogru)
            {
                kalanhak--;
            }

            switch (kalanhak)
            {
                case 0:
                    pictureBox11.Visible = true;
                    oyunbitti();
                    break;
                case 1:
                    pictureBox10.Visible = true;
                    break;
                case 2:
                    pictureBox9.Visible = true;
                    break;
                case 3:
                    pictureBox7.Visible = true;
                    break;
                case 4:
                    pictureBox6.Visible = true;
                    break;
                case 5:
                    pictureBox5.Visible = true;
                    break;
                case 6:
                    pictureBox4.Visible = true;
                    break;
                case 7:
                    pictureBox3.Visible = true;
                    break;
                case 8:
                    pictureBox2.Visible = true;
                    break;
                case 9:
                    pictureBox1.Visible = true;
                    break;
            }

            harfekleme(hrf);
            textBox1.Clear();

        }

        private void levelatlama()
        {
            MessageBox.Show("Level Up!!");
            temizleme();
            rastgelekelime();
        }

        private void oyunbitti()
        {
            MessageBox.Show("Elon is dead. Game Over!!");
            MessageBox.Show("Correct Word: "+secilenkelime);

            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
            baglanti.Open();
            OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
            giris.Parameters.AddWithValue("kullaniciadi", Form1.kulad);
            OleDbDataReader oku = giris.ExecuteReader();
            if (oku.Read())
            {
                if (Convert.ToInt32(oku["oyun2"].ToString()) < skor)
                {
                    OleDbCommand komut = new OleDbCommand("update aaaaa set oyun2='" + skor + "' where kullaniciadi='" + Form1.kulad + "'", baglanti); //oku["sifre"].ToString()
                    komut.ExecuteNonQuery();
                }
            }
            baglanti.Close();

            panel2.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button1.Visible = false;
            label7.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }

        private void guncelleme()
        {
            label6.Text = "";
            foreach (string item in yazilan_harfler)
            {
                label6.Text = label6.Text + item + "";
            }
        }

        private void harfekleme(string harf)
        {
            string[] a = new string[yazilan_harfler.Length + 1];
            for (int z = 0; z < yazilan_harfler.Length; z++)
            {
                a[z] = yazilan_harfler[z];
            }
            a[a.Length - 1] = harf;
            yazilan_harfler = a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string girilenharf = textBox1.Text;
            bool buldu = false;
            bool soylendi = false;
            
            foreach (var item in yazilan_harfler)
            {
                if (girilenharf.ToLower() == item.ToLower())
                {
                    MessageBox.Show("You have already entered this letter!!");
                    soylendi = true;
                }
            }

            textBox1.Clear();

            if (!soylendi)
            {
                for (int i = 0; i < harfler.Length; i++)
                {
                    if (girilenharf.ToLower() == harfler[i].ToLower())
                    {
                        buldu = true;
                        kelimesorgulama(girilenharf);
                        break;
                    }
                }
                if (!buldu)
                {
                    MessageBox.Show("Please Enter A Valid Letter!!");
                    textBox1.Clear();
                }
                guncelleme();
            }
            int sart = label5.Text.IndexOf("_");
            if (sart == -1)
            {
                levelatlama();
            }
        }

        private void temizleme()
        {
            label5.Text = "";
            label6.Text = "";
            textBox1.Clear();
            yazilan_harfler = new string[0];
        }

        private void rastgelekelime()
        {
            Random rastgele = new Random();
            rastgelesayi = rastgele.Next(0, 14);
            secilenkelime = kelimeler[rastgelesayi];
            
            foreach (char item in secilenkelime.ToCharArray())
            {
                label5.Text = label5.Text + "_ ";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rastgelekelime();

            button3.Visible = false;
            button3.Enabled = false;
            panel2.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            button2.Visible = true;
            label4.Visible = true;
            label3.Visible = true;
            label7.Visible = true;
            label7.Text = label7.Text + skor;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you want the elon not to hang, you have to guess the word correctly. Remember, you only have 10 rights.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
            baglanti.Open();
            OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
            giris.Parameters.AddWithValue("kullaniciadi", Form1.kulad);//aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            OleDbDataReader oku = giris.ExecuteReader();
            if (oku.Read())
            {
                if (Convert.ToInt32(oku["oyun2"].ToString()) < skor)
                {
                    OleDbCommand komut = new OleDbCommand("update aaaaa set oyun2='" + skor + "' where kullaniciadi='" + Form1.kulad + "'", baglanti);
                    komut.ExecuteNonQuery();
                }
            }
            baglanti.Close();

            Form3 f3 = new Form3(); 
            f3.Show(); 
            this.Close();
        }
    }
}
