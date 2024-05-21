using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp2
{
    public partial class aktivasyon_kodu : Form
    {
        public aktivasyon_kodu()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage("gamestation.gazi@gmail.com", sifremiunuttum.gonderilenmail, "Password Operations", "Your Verification Code: " + sifremiunuttum.aktivasyon);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("gamestation.gazi@gmail.com", "123123qwe123123");
            smtpClient.Send(mail);
            MessageBox.Show("Your verification code is sent.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == sifremiunuttum.aktivasyon) 
            {
                MessageBox.Show("Your Verification Code Matched.");
                sifredegistirme sifredegis = new sifredegistirme();
                sifredegis.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Your Verification Code Didn't Match!!!");
                textBox1.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
