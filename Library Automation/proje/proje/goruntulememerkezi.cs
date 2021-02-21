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
    public partial class goruntulememerkezi : Form
    {
        public goruntulememerkezi()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=kullanicigirisi.accdb");
        private void goruntulememerkezi_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand kmt = new OleDbCommand();
            kmt.Connection = baglanti;
            string query = "select * from emanetekle";
            kmt.CommandText = query;
            OleDbDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr["uyeadi"].ToString());
                lv.SubItems.Add(dr["kitapadi"].ToString());
                lv.SubItems.Add(Convert.ToDateTime(dr["emanetvermetarihi"].ToString()).ToShortDateString());
                lv.SubItems.Add(Convert.ToDateTime(dr["emanetalmatarihi"].ToString()).ToShortDateString());
                listView1.Items.Add(lv);
            }
            baglanti.Close();
        }
    }
}
