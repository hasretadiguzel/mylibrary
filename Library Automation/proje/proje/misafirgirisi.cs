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
    public partial class misafirgirisi : Form
    {
        public misafirgirisi()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=kullanicigirisi.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_sifre.Text == tb_sifretekrar.Text)
            {
                baglanti.Open();
                OleDbCommand kaydet = new OleDbCommand("insert into kullanicigirisi(Kullanici,Sifre) values('" + tb_kullanici.Text + "','" + tb_sifre.Text + "')", baglanti);
                kaydet.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Yapıldı...");
                kullanicigirisi formsec = new kullanicigirisi();
                formsec.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifreler uyuşmuyor. Lütfen tekrar deneyiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kullanicigirisi formsec = new kullanicigirisi();
            formsec.Show();

            this.Hide();
        }
    }
}
