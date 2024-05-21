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
    public partial class adminpaneli : Form
    {

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\asd.mdb");

        public adminpaneli()
        {
            InitializeComponent();
            listele();
        }

        private void listele()
        {
            baglanti.Open();

            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select *From aaaaa");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kullaniciadi"].ToString());
                ekle.SubItems.Add(oku["sifre"].ToString());
                ekle.SubItems.Add(oku["email"].ToString());
                listView1.Items.Add(ekle);
            }

            baglanti.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            listView2.Visible = true;
            button1.Visible = true;
            button2.Visible = true;

            ListViewItem item = listView1.SelectedItems[0];
            textBox1.Text = item.SubItems[0].Text;
            textBox2.Text = item.SubItems[1].Text;
            textBox3.Text = item.SubItems[2].Text;
            textBox4.Text = item.SubItems[3].Text;

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From aaaaa where kullaniciadi='"+textBox2.Text+"'");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text=oku["oyun1"].ToString();
                ekle.SubItems.Add(oku["oyun2"].ToString());
                ekle.SubItems.Add(oku["oyun3"].ToString());
                ekle.SubItems.Add(oku["oyun4"].ToString());
                ekle.SubItems.Add(oku["oyun5"].ToString());
                ekle.SubItems.Add(oku["oyun6"].ToString());

                listView2.Items.Add(ekle);
            }

            baglanti.Close();

            ListViewItem itemm = listView2.Items[0];
            textBox5.Text = itemm.SubItems[0].Text;
            textBox6.Text = itemm.SubItems[1].Text;
            textBox7.Text = itemm.SubItems[2].Text;
            textBox8.Text = itemm.SubItems[3].Text;
            textBox9.Text = itemm.SubItems[4].Text;
            textBox10.Text = itemm.SubItems[5].Text;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "Update aaaaa set sifre='" + textBox3.Text + "',email='" + textBox4.Text + "',oyun1='" + textBox5.Text + "',oyun2='" + textBox6.Text + "',oyun3='" + textBox7.Text + "',oyun4='" + textBox8.Text + "',oyun5='" + textBox9.Text + "',oyun6='" + textBox10.Text + "' where kullaniciadi='" + textBox2.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listView2.Items.Clear();
            baglanti.Open();
            OleDbCommand komutt = new OleDbCommand();
            komutt.Connection = baglanti;
            komutt.CommandText = ("Select * From aaaaa where kullaniciadi='" + textBox2.Text + "'");
            OleDbDataReader oku = komutt.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["oyun1"].ToString();
                ekle.SubItems.Add(oku["oyun2"].ToString());
                ekle.SubItems.Add(oku["oyun3"].ToString());
                ekle.SubItems.Add(oku["oyun4"].ToString());
                ekle.SubItems.Add(oku["oyun5"].ToString());
                ekle.SubItems.Add(oku["oyun6"].ToString());

                listView2.Items.Add(ekle);
            }
            baglanti.Close();

            listView1.Items.Clear();

            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand();
            komut1.Connection = baglanti;
            komut1.CommandText = ("Select *From aaaaa");
            OleDbDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku1["id"].ToString();
                ekle1.SubItems.Add(oku1["kullaniciadi"].ToString());
                ekle1.SubItems.Add(oku1["sifre"].ToString());
                ekle1.SubItems.Add(oku1["email"].ToString());
                listView1.Items.Add(ekle1);
            }
            baglanti.Close();

            MessageBox.Show("Your data succesfully updated.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="admin")
            {
                MessageBox.Show("You cannot delete this user!!!");
            }
            else
            {
                listView1.Items.Clear();
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = baglanti;
                komut.CommandText = "delete *from aaaaa where kullaniciadi='" + textBox2.Text + "'";
                komut.ExecuteNonQuery();

                OleDbCommand komutt = new OleDbCommand();
                komutt.Connection = baglanti;
                komutt.CommandText = ("Select *From aaaaa");
                OleDbDataReader oku = komutt.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["id"].ToString();
                    ekle.SubItems.Add(oku["kullaniciadi"].ToString());
                    ekle.SubItems.Add(oku["sifre"].ToString());
                    ekle.SubItems.Add(oku["email"].ToString());
                    listView1.Items.Add(ekle);
                }

                baglanti.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                listView2.Items.Clear();
                baglanti.Close();
            }
        }
    }
}
