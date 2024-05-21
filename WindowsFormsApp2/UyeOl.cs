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
    public partial class UyeOl : Form
    {
        public UyeOl()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nickname")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Nickname";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "E-mail")
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "E-mail";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';
            }
        }

        char? boşluk = null;
        char? boşlukk = null;

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.PasswordChar = Convert.ToChar(boşluk);
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Password Again")
            {
                textBox3.Text = "";
                textBox3.PasswordChar = '*';
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Password Again";
                textBox3.PasswordChar = Convert.ToChar(boşlukk);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        int mouse_x;
        int mouse_y;

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

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords you entered did not match!!");
                UyeOl uye = new UyeOl();
                uye.Show();
                this.Close();
            }
            else
            {
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
                baglanti.Open();
                OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
                giris.Parameters.AddWithValue("kullaniciadi", textBox1.Text);
                OleDbDataReader oku = giris.ExecuteReader();

                OleDbCommand giris2 = new OleDbCommand("select *from aaaaa where email=@email", baglanti);
                giris2.Parameters.AddWithValue("email", textBox4.Text);
                OleDbDataReader oku2 = giris2.ExecuteReader();

                int kontrol = textBox4.Text.IndexOf('@');
                if (oku.Read())
                {
                    MessageBox.Show("Same Username Exists");
                    UyeOl uyeolma = new UyeOl();
                    uyeolma.Show();
                    this.Close();
                }
                else if (oku2.Read())
                {
                    MessageBox.Show("Same E-Mail Exists");
                    UyeOl uyeolma = new UyeOl();
                    uyeolma.Show();
                    this.Close();
                }
                else if (kontrol==-1)
                {
                    MessageBox.Show("This is not a valid e-mail address.");
                    UyeOl uyeolma = new UyeOl();
                    uyeolma.Show();
                    this.Close();
                }
                else
                {
                    OleDbCommand komut = new OleDbCommand("Insert Into aaaaa (kullaniciadi , sifre , email) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    this.Close();
                    Form1 f1 = new Form1();
                    f1.Show();
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }



    }
}
