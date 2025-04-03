using System;
using MySql.Data.MySqlClient;

namespace LabExam
{
    public class Database
    {
        private string connectionString = "server=localhost;database=studentinfodb;user=root;password='';";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
