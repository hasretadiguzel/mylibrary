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
    public partial class kitapekle : Form
    {
        public kitapekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=" + Application.StartupPath + "\\kullanicigirisi.accdb");
        public int kayit_sayisi()
        {
            return listView1.Items.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kitapadi = "", yazar = "", baskiyili = "", sayfasayisi = "", dili = "", yayinevi = "";

            kitapadi = textBox1.Text;
            yazar = textBox2.Text;
            baskiyili = textBox4.Text;
            sayfasayisi = textBox5.Text;
            dili = comboBox1.Text;
            yayinevi= textBox3.Text;

            string[] bilgiler = { kitapadi ,yazar, baskiyili, sayfasayisi, dili, yayinevi };

            bool kayitvarmi = false;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == kitapadi)
                {
                    kayitvarmi = true;
                    MessageBox.Show("Bu kitap zaten kayıtlıdır!");
                }
            }

            if (kayitvarmi != true)
            {
                ListViewItem list = new ListViewItem(bilgiler);
                if (kitapadi != "" && yazar != "" && baskiyili != "" && sayfasayisi != "" && dili != "" && yayinevi != "")
                {
                    listView1.Items.Add(list);
                   
                    baglanti.Open();
                    OleDbCommand kitapekle = new OleDbCommand("insert into kitapekle(kitapadi,yazar,baskiyili,sayfasayisi,dili,yayinevi) values('" + kitapadi + "','" + yazar + "','" + baskiyili + "','" + sayfasayisi + "','" + dili + "','" + yayinevi + "')", baglanti);
                    kitapekle.ExecuteNonQuery();
                    baglanti.Close();

                    listView1.Items.Clear();
                    baglanti.Open();
                    OleDbCommand kmt = new OleDbCommand();
                    kmt.Connection = baglanti;
                    string query = "select * from kitapekle";
                    kmt.CommandText = query;

                    OleDbDataReader dr = kmt.ExecuteReader();
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem(dr["kitapadi"].ToString());
                        item.SubItems.Add(dr["yazar"].ToString());
                        item.SubItems.Add(dr["baskiyili"].ToString());
                        item.SubItems.Add(dr["sayfasayisi"].ToString());
                        item.SubItems.Add(dr["dili"].ToString());
                        item.SubItems.Add(dr["yayinevi"].ToString());
                        listView1.Items.Add(item);
                    }
                    baglanti.Close();

                }
                else
                    MessageBox.Show("Formda boş alanlar bırakmayınız");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region kayıtsilme
            baglanti.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = baglanti;

            string query = "delete from kitapekle where Id=" + tb_ID.Text + "";
            kmt.CommandText = query;
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ID numarası " + tb_ID.Text + " olan kayıt silinmiştir.");
            tb_ID.Text = "";
            #endregion
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand kmt1 = new OleDbCommand();
            kmt1.Connection = baglanti;
            string query1 = "select * from kitapekle";
            kmt1.CommandText = query1;

            OleDbDataReader dr = kmt1.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Id"].ToString());
                item.SubItems.Add(dr["kitapadi"].ToString());
                item.SubItems.Add(dr["yazar"].ToString());
                item.SubItems.Add(dr["baskiyili"].ToString());
                item.SubItems.Add(dr["sayfasayisi"].ToString());
                item.SubItems.Add(dr["dili"].ToString());
                item.SubItems.Add(dr["yayinevi"].ToString());
                listView1.Items.Add(item);
            }
            baglanti.Close();
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            
                
                listView1.Items.Clear();
                baglanti.Open();
                OleDbCommand kmt = new OleDbCommand();
                kmt.Connection = baglanti;
                string query = "select * from kitapekle";
                kmt.CommandText = query;

                OleDbDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                ListViewItem item = new ListViewItem(dr["Id"].ToString());
                item.SubItems.Add(dr["kitapadi"].ToString());
                item.SubItems.Add(dr["yazar"].ToString());
                item.SubItems.Add(dr["baskiyili"].ToString());
                item.SubItems.Add(dr["sayfasayisi"].ToString());
                item.SubItems.Add(dr["dili"].ToString());
                item.SubItems.Add(dr["yayinevi"].ToString());
                listView1.Items.Add(item);
            }
                baglanti.Close();

        }

        private void üyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            üyeekle formsec3 = new üyeekle();
            formsec3.Show();

            this.Hide();
        }
        
        private void hakkındaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İSTANBUL ÜNİVERSİTESİ - CERRAHPAŞA \nHasret Adıgüzel \nHüseyin Demirtürk");
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emanetekle formsec4 = new emanetekle();
            formsec4.Show();

            this.Hide();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
