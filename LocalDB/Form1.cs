using Microsoft.Data.Sqlite;
using System.Diagnostics;
namespace LocalDB
{
    public partial class Form1 : Form
    {
        private string dbPath;
        private string connectionString;
        private DatabaseHelper db;

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

            db = new DatabaseHelper(connectionString);
        }

        // Insert into the database
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            db.AddStudent(
                txtName.Text,
                txtGrade.Text);

            MessageBox.Show("Student Added");

        }

        // Load students from the database 
        private void btnLoadStudents_Click(object sender, EventArgs e)
        {
            lstStudents.Items.Clear();

            List<Student> students = db.GetStudents();
            foreach (Student student in students)
            {
                lstStudents.Items.Add($"{student.Id} - {student.Name} - {student.Grade}");
            }
        }

        // Create Dabase and Table - Only need to run once, then comment out the code below
        /*
        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            db.CreateDatabase();

            MessageBox.Show("Database Created");
        }
        */

    }
}
