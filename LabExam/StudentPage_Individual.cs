using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LabExam
{
    public partial class StudentPage_Individual : Form
    {
        private int studentId; // Store studentId
        private Database db = new Database(); // Database connection class

        public StudentPage_Individual(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId; // Store the passed student ID
        }

        private void StudentPage_Individual_Load(object sender, EventArgs e)
        {
            LoadStudentDetails();
        }

        private void LoadStudentDetails()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM studentrecordtb WHERE studentId = @studentId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read()) // If data is found
                        {
                            StudentIdTxt.Text = reader["studentId"].ToString();
                            FirstNameTxt.Text = reader["firstName"].ToString();
                            LastNameTxt.Text = reader["lastName"].ToString();
                            MiddleNameTxt.Text = reader["middleName"].ToString();
                            HouseNumberTxt.Text = reader["houseNo"].ToString();
                            BaranggayNameTxt.Text = reader["brgyName"].ToString();
                            MunicipalityTxt.Text = reader["municipality"].ToString();
                            ProvinceTxt.Text = reader["province"].ToString();
                            RegionTxt.Text = reader["region"].ToString();
                            CountryTxt.Text = reader["country"].ToString();
                            BirthDateTxt.Text = reader["birthdate"].ToString();
                            AgeTxt.Text = reader["age"].ToString();
                            ContactNumberTxt.Text = reader["studContactNo"].ToString();
                            EmailTxt.Text = reader["emailAddress"].ToString();
                            GuardianNameTxt.Text = reader["guardianFirstName"].ToString();
                            GuardianLastNameTxt.Text = reader["guardianLastName"].ToString();
                            HobbiesTxt.Text = reader["hobbies"].ToString();
                            NicknameTxt.Text = reader["nickname"].ToString();
                            CourseIdTxt.Text = reader["courseId"].ToString();
                            YearIdTxt.Text = reader["yearId"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("Student not found!");
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
