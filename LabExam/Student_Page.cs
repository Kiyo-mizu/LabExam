using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LabExam
{
    public partial class Student_Page : Form
    {
        private Database db = new Database();

        public Student_Page()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT studentId, CONCAT(firstName, ' ', lastName) AS Fullname FROM studentrecordtb";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    // Add "View" button if not already added
                    if (!dataGridView1.Columns.Contains("View"))
                    {
                        DataGridViewButtonColumn viewButton = new DataGridViewButtonColumn
                        {
                            Name = "Action",
                            Text = "VIEW",
                            UseColumnTextForButtonValue = true
                        };
                        dataGridView1.Columns.Add(viewButton);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Action"].Index && e.RowIndex >= 0)
            {
                int studentId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["StudentId"].Value);
                StudentPage_Individual studentForm = new StudentPage_Individual(studentId);
                studentForm.ShowDialog();
            }
        }

    }
}
