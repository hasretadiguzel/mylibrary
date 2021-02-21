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
    public partial class emanetekle : Form
    {
        public emanetekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\kullanicigirisi.accdb");
        private void kitapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapekle formsec2 = new kitapekle();
            formsec2.Show();

            this.Hide();
        }

        private void üyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            üyeekle formsec3 = new üyeekle();
            formsec3.Show();

            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 50;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 50;
            progressBar1.Step = 5;
            progressBar1.Style = ProgressBarStyle.Continuous;

            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = baglanti;
            string query = "select * from emanetekle";
            kmt.CommandText = query;

            OleDbDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Id"].ToString());
                item.SubItems.Add(dr["uyeadi"].ToString());
                item.SubItems.Add(dr["kitapadi"].ToString());
                item.SubItems.Add(Convert.ToDateTime(dr["emanetvermetarihi"].ToString()).ToShortDateString());
                item.SubItems.Add(Convert.ToDateTime(dr["emanetalmatarihi"].ToString()).ToShortDateString());
                item.SubItems.Add(dr["mesaj"].ToString());
                listView1.Items.Add(item);
            }
            baglanti.Close();

            #region cbadi
            baglanti.Open();
            OleDbCommand kmt2 = new OleDbCommand();
            kmt2.Connection = baglanti;
            string query1 = "select * from uyeekle";
            kmt2.CommandText = query1;
            OleDbDataReader dr2 = kmt2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2["Adi"].ToString());
            }
            baglanti.Close();
            #endregion

            #region cbkitapadi
            baglanti.Open();
            OleDbCommand kmt3 = new OleDbCommand();
            kmt2.Connection = baglanti;
            string query2 = "select * from kitapekle";
            kmt2.CommandText = query2;
            OleDbDataReader dr3 = kmt2.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3["kitapadi"].ToString());
            }
            baglanti.Close();
            #endregion
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int yaziUzunluk = textBox1.TextLength;
            int deger = (int)yaziUzunluk * 50 / textBox1.MaxLength;
            progressBar1.Value = deger;
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İSTANBUL ÜNİVERSİTESİ - CERRAHPAŞA \nHasret Adıgüzel \nHüseyin Demirtürk ");
        }
        public int kayit_sayisi()
        {
            return listView1.Items.Count;
        }
        private void button1_Click(object sender, EventArgs e)
        {


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "AA '/' gg '/' yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "AA '/' gg '/' yyyy";


            baglanti.Open();
            OleDbCommand kitapekle = new OleDbCommand("insert into emanetekle(uyeadi,kitapadi,emanetvermetarihi,emanetalmatarihi,mesaj) values('" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + dateTimePicker1.Value.Date + "','" + dateTimePicker2.Value.Date + "','" + textBox1.Text + "')", baglanti);
            kitapekle.ExecuteNonQuery();
            baglanti.Close();

                listView1.Items.Clear();
                    baglanti.Open();
                    OleDbCommand kmt = new OleDbCommand();
                    kmt.Connection = baglanti;
                    string query = "select * from emanetekle";
                    kmt.CommandText = query;

                    OleDbDataReader dr = kmt.ExecuteReader();
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem(dr["Id"].ToString());
                        item.SubItems.Add(dr["uyeadi"].ToString());
                        item.SubItems.Add(dr["kitapadi"].ToString());
                        item.SubItems.Add(dr["emanetvermetarihi"].ToString());
                        item.SubItems.Add(dr["emanetalmatarihi"].ToString());
                        item.SubItems.Add(dr["mesaj"].ToString());
                        listView1.Items.Add(item);
                    }
                    baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = baglanti;

            string query = "delete from emanetekle where Id=" + tb_ID.Text + "";
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
            string query1 = "select * from emanetekle";
            kmt1.CommandText = query1;

            OleDbDataReader dr = kmt1.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Id"].ToString());
                item.SubItems.Add(dr["uyeadi"].ToString());
                item.SubItems.Add(dr["kitapadi"].ToString());
                item.SubItems.Add(dr["emanetvermetarihi"].ToString());
                item.SubItems.Add(dr["emanetalmatarihi"].ToString());
                item.SubItems.Add(dr["mesaj"].ToString());
                listView1.Items.Add(item);
            }
            baglanti.Close();
            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
            }
    }
}
