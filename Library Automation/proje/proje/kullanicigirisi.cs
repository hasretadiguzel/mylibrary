using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace proje
{
    public partial class kullanicigirisi : Form
    {
        public kullanicigirisi()
        {
            InitializeComponent();
        }
        
        private void Kullanıcıgirisi_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=kullanicigirisi.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            baglanti.Open();
            
            OleDbCommand conn = new OleDbCommand( "SELECT *FROM kullanicigirisi WHERE Kullanici='" + textBox1.Text + "' AND Sifre='" + textBox2.Text + "'" , baglanti);

            OleDbDataReader dr = conn.ExecuteReader();
            if (dr.Read())
            {
                giris form1 = new giris();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş. Tekrar Deneyiniz");
            }

        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {

            

        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            misafirgirisi formsec = new misafirgirisi();
            formsec.Show();

            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            goruntulememerkezi formsec = new goruntulememerkezi();
            formsec.Show();

            this.Hide();
        }
    }
}
