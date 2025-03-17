using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuizBiz
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        private string connectionString = "Server=DESKTOP-JSURCDB;Database=QuizBiz;Trusted_Connection=True;";


        public Form4()
        {
            InitializeComponent();
        }

    

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBox24.PasswordChar = metroCheckBox1.Checked ? '\0' : '*';
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string CustUsername = metroTextBox23.Text;
            string CustPassword = metroTextBox24.Text;

            if (ValidateUser(CustUsername, CustPassword))
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
            else
            {
                metroLabel2.Text = "Invalid Username or Password.";
            }
        }

        private bool ValidateUser(string CustUsername, string CustPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Customers WHERE CustUsername = @CustUsername AND CustPassword = @CustPassword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustUsername", CustUsername);
                    command.Parameters.AddWithValue("@CustPassword", CustPassword);

                    int count = (int)command.ExecuteScalar();
                    return count > 0; 
                }
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        private void metroLabel30_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox24_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel27_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel28_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox23_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel29_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
