using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuizBiz
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        private string connectionString = "Server=DESKTOP-JSURCDB;Database=QuizBiz;Trusted_Connection=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string CustUsername = create1.Text;
            string CustPassword = create2.Text;

            if (CreateUser (CustUsername, CustPassword))
            {               
                MessageBox.Show("Account Successfully Created!");
                var form4 = new Form4();
                form4.Show();
            }
            else
            {
                createLabel2.Text = "Error: Username already exists or invalid input.";
            }
        }
        private bool CreateUser(string CustUsername, string CustPassword)
        {
            
            if (string.IsNullOrWhiteSpace(CustUsername) || string.IsNullOrWhiteSpace(CustPassword))
            {
                return false; 
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Customers WHERE CustUsername = @CustUsername";

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@CustUsername", CustUsername);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        return false; 
                    }
                }
                string query = "INSERT INTO Customers (CustUsername, CustPassword) VALUES (@CustUsername, @CustPassword)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustUsername", CustUsername);
                    command.Parameters.AddWithValue("@CustPassword", CustPassword); 

                    try
                    {
                        command.ExecuteNonQuery();
                        return true; 
                    }
                    catch (SqlException ex)
                    {
                        
                        if (ex.Number == 2627) 
                        {
                            return false; 
                        }
                        else
                        {
                            throw; 
                        }
                    }
                }
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            create2.PasswordChar = metroCheckBox2.Checked ? '\0' : '*';
        }

        private void create1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
