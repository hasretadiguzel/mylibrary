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

namespace proje
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kitapekle formsec2 = new kitapekle();
                formsec2.Show(); 

            this.Hide();
        }

        private void hakkındaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İSTANBUL ÜNİVERSİTESİ - CERRAHPAŞA \nHasret Adıgüzel \nHüseyin Demirtürk ");
        }

        private void üyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            üyeekle formsec3 = new üyeekle();
            formsec3.Show();

            this.Hide();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emanetekle formsec4 = new emanetekle();
            formsec4.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emanetekle formsec4 = new emanetekle();
            formsec4.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            üyeekle formsec3 = new üyeekle();
            formsec3.Show();

            this.Hide();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kitapEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kitapekle formsec3 = new kitapekle();
            formsec3.Show();

            this.Hide();
        }
    }
}
