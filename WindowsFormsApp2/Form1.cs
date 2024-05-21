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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();

        }
        bool move;
        int mouse_x;
        int mouse_y;


        public static string kulad;

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
            baglanti.Open();
            OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi and sifre=@sifre", baglanti);
            giris.Parameters.AddWithValue("kullaniciadi", textBox1.Text);
            giris.Parameters.AddWithValue("sifre", textBox2.Text);
            OleDbDataReader oku = giris.ExecuteReader();
            if (oku.Read())
            {
                if (textBox1.Text == "admin") 
                {
                    adminpaneli admin = new adminpaneli();
                    admin.Show();
                    this.Hide();
                }
                else
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Wrong Id or Password");
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            kulad = textBox1.Text;
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\ses3.wav";
            ses.SoundLocation = dizin;
            ses.Play();
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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';
            }
        }

        char? boşluk = null;

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.PasswordChar = Convert.ToChar(boşluk);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = Convert.ToChar(boşluk);
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.telegram.org/#/login");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/?lang=tr");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UyeOl uyeol = new UyeOl();
            uyeol.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremiunuttum sifreunuttum = new sifremiunuttum();
            sifreunuttum.Show();
            this.Hide();
        }

    }
}
