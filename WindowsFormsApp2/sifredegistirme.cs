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

namespace WindowsFormsApp2
{
    public partial class sifredegistirme : Form
    {

        public sifredegistirme()
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

        char? bosluk = null;
        char? boslukk = null;

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Password")
            {
                textBox1.Text = "";
                textBox1.PasswordChar = '*';
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Password";
                textBox1.PasswordChar = Convert.ToChar(bosluk);
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password Again")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password Again";
                textBox2.PasswordChar = Convert.ToChar(boslukk);
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
            if (textBox1.Text==textBox2.Text)
            {
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");
                baglanti.Open();

                OleDbCommand giris = new OleDbCommand("select *from aaaaa where kullaniciadi='"+sifremiunuttum.kullanici+"'", baglanti);
                OleDbDataReader oku = giris.ExecuteReader();
                if (oku.Read())
                {
                    OleDbCommand komut = new OleDbCommand("update aaaaa set sifre='" + textBox1.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Your Password has been successfully changed.");
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("bak girdin krdşm.");
                    baglanti.Close();
                } 
            }
            else
            {
                MessageBox.Show("Passwords Didn't Match!!!");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
