using Microsoft.Data.Sqlite;
using System.Diagnostics;
namespace LocalDB
{
    public partial class Form1 : Form
    {
        private string dbPath;
        private string connectionString;

        public Form1()
        {
            InitializeComponent();

            // Set the database path to a folder outside of the bin directory
            // so it can be accessed easily and not be deleted when the project is rebuilt
            dbPath = Path.Combine(
                Directory.GetParent(Application.StartupPath)!.Parent!.Parent!.Parent!.FullName,
                "Data",
                "StudentDatabase.db");

            Directory.CreateDirectory(
                Path.GetDirectoryName(dbPath)!);

            connectionString = $"Data Source={dbPath}";

            Debug.WriteLine(Application.StartupPath);
        }

        // Insert into the database
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
               """
                INSERT INTO Students (Name, Grade)
                VALUES ($name, $grade);
                """;

            command.Parameters.AddWithValue("$name", txtName.Text);
            command.Parameters.AddWithValue("$grade", txtGrade.Text);

            command.ExecuteNonQuery();

            MessageBox.Show("Student Added");

        }

        // Load students from the database 
        private void btnLoadStudents_Click(object sender, EventArgs e)
        {
            lstStudents.Items.Clear();

            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
                """
                SELECT *
                FROM Students;
                """;

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                lstStudents.Items.Add(
                    $"{reader["Id"]} - {reader["Name"]} - {reader["Grade"]}");
            }
        }

        // Create Dabase and Table - Only need to run once, then comment out the code below
        /*
        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(
                Path.GetDirectoryName(dbPath)!);

            using var connection = new SqliteConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
               """
                CREATE TABLE IF NOT EXISTS Students
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Grade TEXT
                );
                """;

            command.ExecuteNonQuery();

            MessageBox.Show("Database Created");
        }
        */

    }
}
