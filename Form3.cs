using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizBiz
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
            txtSearch.KeyPress += txtSearch_KeyPress;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtSearch.Text.Equals("Send a Package", StringComparison.OrdinalIgnoreCase))
                {
                    var form1 = new Form1();
                    form1.Show(); 
                    this.Hide(); 
                }
                if (txtSearch.Text.Equals("Transactions", StringComparison.OrdinalIgnoreCase))
                {
                    var form5 = new Form5();
                    form5.Show();
                    this.Hide();
                }
              
                txtSearch.Clear();
                e.Handled = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
