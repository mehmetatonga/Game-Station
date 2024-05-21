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
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp2
{
    public partial class sifremiunuttum : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        public static string gonderilenmail;
        public static string aktivasyon;
        public static string kullanici;

        public sifremiunuttum()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
            baglanti.Open();
            OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi=@kullaniciadi", baglanti);
            giris.Parameters.AddWithValue("kullaniciadi", textBox1.Text);
            OleDbDataReader oku = giris.ExecuteReader();
            Random rnd = new Random();
            aktivasyon = rnd.Next(100000, 999999).ToString();
            if (oku.Read())
            {
                if (textBox2.Text== oku["email"].ToString())
                {
                    gonderilenmail = textBox2.Text;
                    kullanici = textBox1.Text;
                    MailMessage mail = new MailMessage("gamestation.gazi@gmail.com", textBox2.Text, "Password Operations", "Your Verification Code: " + aktivasyon);
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential("gamestation.gazi@gmail.com", "123123qwe123123");
                    smtpClient.Send(mail);
                    MessageBox.Show("Your verification code is sent.");
                    aktivasyon_kodu ak = new aktivasyon_kodu();
                    ak.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("The E-Mail Couldn't Authenticate");
                }
            }
            else
            {
                MessageBox.Show("The User Couldn't Authenticate");
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
            if (textBox2.Text == "E-Mail")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "E-Mail";
            }
        }
    }
}
