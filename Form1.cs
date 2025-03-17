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
using static MetroFramework.Drawing.MetroPaint.BackColor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuizBiz
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private string connectionString = "Server=DESKTOP-JSURCDB;Database=QuizBiz;Trusted_Connection=True;";

        public Form1()
        {
         InitializeComponent(); 
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel28_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            InsertSendData();
            InsertReceiverData();
            InsertPackageDetails();

            
            DateTime currentDate = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Transactions (dateTime) VALUES (@dateTime)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dateTime", currentDate);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Date registered successfully: " + currentDate.ToString("MMMM dd, yyyy"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void InsertPackageDetails()
        {
            string packageQuery = "INSERT INTO Package (packName, packDescription, itemValue) " +
                                  "VALUES (@packName, @packDescription, @itemValue)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand packageCommand = new SqlCommand(packageQuery, connection))
                {
                    packageCommand.Parameters.AddWithValue("@packName", txtpackName.Text);
                    packageCommand.Parameters.AddWithValue("@packDescription", txtpackDesc.Text);
                    packageCommand.Parameters.AddWithValue("@itemValue", txtpackVal.Text);

                    try
                    {
                        connection.Open(); 
                        packageCommand.ExecuteNonQuery(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting package details: " + ex.Message);
                    }
                }
            }
        }

        private void InsertReceiverData()
        {
            string query = "INSERT INTO Receive (recFname, recLname, recNumb, recFloor, recStreet, recProv, recCity, recBar, recZip, recLand) " +
                           "VALUES (@recFname, @recLname, @recNumb, @recFloor, @recStreet, @recProv, @recCity, @recBar, @recZip, @recLand)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@recFname", txtrecFname.Text);
                    command.Parameters.AddWithValue("@recLname", txtrecLname.Text);
                    command.Parameters.AddWithValue("@recNumb", txtrecNum.Text);
                    command.Parameters.AddWithValue("@recFloor", txtrecAdd.Text);
                    command.Parameters.AddWithValue("@recStreet", txtrecStreet.Text);
                    command.Parameters.AddWithValue("@recProv", txtrecProv.Text);
                    command.Parameters.AddWithValue("@recCity", txtrecCity.Text);
                    command.Parameters.AddWithValue("@recBar", txtrecBar.Text);
                    command.Parameters.AddWithValue("@recZip", txtrecZip.Text);
                    command.Parameters.AddWithValue("@recLand", txtrecLand.Text);

                    try
                    {
                        connection.Open(); 
                        command.ExecuteNonQuery(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting receiver data: " + ex.Message);
                    }
                }
            }
        }

        private void InsertSendData()
        {
            string query = "INSERT INTO Send (sendFname, sendLname, sendNumb, sendFloor, sendStreet, sendProv, sendCity, sendBar, sendZip, sendLand, sendSched) " +
                           "VALUES (@sendFname, @sendLname, @sendNumb, @sendFloor, @sendStreet, @sendProv, @sendCity, @sendBar, @sendZip, @sendLand, @sendSched)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sendFname", txtsendFname.Text);
                    command.Parameters.AddWithValue("@sendLname", txtsendLname.Text);
                    command.Parameters.AddWithValue("@sendNumb", txtsendNumb.Text);
                    command.Parameters.AddWithValue("@sendFloor", txtsendFloor.Text);
                    command.Parameters.AddWithValue("@sendStreet", txtsendStreet.Text);
                    command.Parameters.AddWithValue("@sendProv", txtsendProv.Text);
                    command.Parameters.AddWithValue("@sendCity", txtsendCity.Text);
                    command.Parameters.AddWithValue("@sendBar", txtsendBar.Text);
                    command.Parameters.AddWithValue("@sendZip", txtsendZip.Text);
                    command.Parameters.AddWithValue("@sendLand", txtsendLand.Text);
                    command.Parameters.AddWithValue("@sendSched", txtsendSched2.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Thank you! Your delivery information has been successfully submitted. Your order is being processed and will be delivered soon.");
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }
        private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        }

        private void txtsendZip_Click(object sender, EventArgs e)
        {

        }

        private void txtsendSched_Click(object sender, EventArgs e)
        {

        }

        private void txtrecLname_Click(object sender, EventArgs e)
        {

        }

        private void txtrecNum_Click(object sender, EventArgs e)
        {

        }

        private void txtrecAdd_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex < metroTabControl1.TabCount - 1)
            {
                metroTabControl1.SelectedIndex++;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex > 0)
            {
                metroTabControl1.SelectedIndex--;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex < metroTabControl1.TabCount - 1)
            {
                metroTabControl1.SelectedIndex++;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex > 0)
            {
                metroTabControl1.SelectedIndex--;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
