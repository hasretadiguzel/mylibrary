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

namespace proje
{
    public partial class üyeekle : Form
    {
        public üyeekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\kullanicigirisi.accdb");
        private void emanetEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emanetekle formsec4 = new emanetekle();
            formsec4.Show();

            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox3.MaxLength = 50;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 50;
            progressBar1.Step = 5;
            progressBar1.Style = ProgressBarStyle.Continuous;

            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = baglanti;
            string query = "select * from uyeekle";
            kmt.CommandText = query;

            OleDbDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Id"].ToString());
                item.SubItems.Add(dr["Adi"].ToString());
                item.SubItems.Add(dr["Soyadi"].ToString());
                item.SubItems.Add(dr["Telefon"].ToString());
                item.SubItems.Add(dr["Eposta"].ToString());
                item.SubItems.Add(dr["Adres"].ToString());
                listView1.Items.Add(item);
            }
            baglanti.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int yaziUzunluk = textBox3.TextLength;
            int deger = (int)yaziUzunluk * 50 / textBox3.MaxLength;
            progressBar1.Value = deger;
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İSTANBUL ÜNİVERSİTESİ - CERRAHPAŞA \nHasret Adıgüzel \nHüseyin Demirtürk");
        }

        private void kToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapekle formsec2 = new kitapekle();
            formsec2.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand kitapekle = new OleDbCommand("insert into uyeekle(Adi,Soyadi,Telefon,Eposta,Adres) values('" + textBox1.Text+ "','" + textBox2.Text+ "','" + maskedTextBox1.Text + "','" + textBox4.Text+ "','" + textBox3.Text+ "')", baglanti);
            kitapekle.ExecuteNonQuery();
            baglanti.Close();

            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = baglanti;
            string query = "select * from uyeekle";
            kmt.CommandText = query;

            OleDbDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Id"].ToString());
                item.SubItems.Add(dr["Adi"].ToString());
                item.SubItems.Add(dr["Soyadi"].ToString());
                item.SubItems.Add(dr["Telefon"].ToString());
                item.SubItems.Add(dr["Eposta"].ToString());
                item.SubItems.Add(dr["Adres"].ToString());
                listView1.Items.Add(item);
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = baglanti;

            string query = "delete from uyeekle where Id=" + tb_ID.Text + "";
            kmt.CommandText = query;
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ID numarası " + tb_ID.Text + " olan kayıt silinmiştir.");
            tb_ID.Text = "";



            #region listview tekrar çalıştırma
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand kmt1 = new OleDbCommand();
            kmt1.Connection = baglanti;
            string query1 = "select * from uyeekle";
            kmt1.CommandText = query1;

            OleDbDataReader dr = kmt1.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Id"].ToString());
                item.SubItems.Add(dr["Adi"].ToString());
                item.SubItems.Add(dr["Soyadi"].ToString());
                item.SubItems.Add(dr["Telefon"].ToString());
                item.SubItems.Add(dr["Eposta"].ToString());
                item.SubItems.Add(dr["Adres"].ToString());
                listView1.Items.Add(item);
            }
            baglanti.Close();
            #endregion
        }
    }
}
