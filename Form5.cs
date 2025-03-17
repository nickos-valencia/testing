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

namespace QuizBiz
{
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        public Form5()
        {
            InitializeComponent();
            
        }

        private void LoadData()
        {
            dataGridViewTransactions.Rows.Clear();
            string connectionString = "Server=DESKTOP-JSURCDB;Database=QuizBiz;Trusted_Connection=True;";
            string query = @"
                SELECT 
                    t.transacID, 
                    t.dateTime, 
                    s.sendFname, 
                    s.sendLname, 
                    r.recFname, 
                    r.recLname, 
                    p.packName, 
                    p.packDescription, 
                    p.itemValue
                FROM Transactions t
                JOIN Send s ON t.sendID = s.sendID
                JOIN Receive r ON t.recID = r.recID
                JOIN Package p ON t.packID = p.packID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewTransactions.DataSource = dataTable; 
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
