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
    public partial class highscore : Form
    {
        bool move;
        int mouse_x;
        int mouse_y;
        int sayac = 0;

        public highscore()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");

        private void verilerigoruntule()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText=("Select * From aaaaa");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kullaniciadi"].ToString();
                ekle.SubItems.Add(oku["oyun1"].ToString());
                ekle.SubItems.Add(oku["oyun2"].ToString());
                ekle.SubItems.Add(oku["oyun3"].ToString());
                ekle.SubItems.Add(oku["oyun4"].ToString());
                ekle.SubItems.Add(oku["oyun5"].ToString());
                ekle.SubItems.Add(oku["oyun6"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verilerigoruntule();
            button2.Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
            baglanti.Open();
            OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi='"+Form1.kulad+"'", baglanti);
            OleDbDataReader oku = giris.ExecuteReader();
            if (oku.Read() && sayac == 0) 
            {
                 MailMessage mail = new MailMessage("gamestation.gazi@gmail.com", oku["email"].ToString(), "Password Operations", "Your Scores:" + Environment.NewLine +"Flappy SpaceShip: "+ oku["oyun1"].ToString() + Environment.NewLine +"Hang Elon: "+ oku["oyun2"].ToString() + Environment.NewLine +"PacSpaceMan: "+ oku["oyun3"].ToString() + Environment.NewLine +"Space Snake: "+ oku["oyun4"].ToString() + Environment.NewLine +"Coin Hunter Elon: "+ oku["oyun5"].ToString() + Environment.NewLine +"SpaceBall: "+ oku["oyun6"].ToString() + Environment.NewLine + "Thank you for choosing us and playing our game. Have a good day.");
                 SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                 smtpClient.EnableSsl = true; //MessageBox.Show("Game Over!" + Environment.NewLine + "We've lost coins" + Environment.NewLine + "Click ok to retry");
                 smtpClient.Credentials = new NetworkCredential("gamestation.gazi@gmail.com", "123123qwe123123");
                 smtpClient.Send(mail);
                 MessageBox.Show("Your scores are sent.");
                 sayac++;
            }
            else
            {
                MessageBox.Show("We have recently sent your scores to your e-mail." + Environment.NewLine + "Please try again later.");
            }
            baglanti.Close();
        }

    }
}
