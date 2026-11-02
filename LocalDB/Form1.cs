using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Windows.Forms;
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

            // Configure DataGridView
            dataGridView.ColumnCount = 4;
            dataGridView.Columns[0].Name = "ID";
            dataGridView.Columns[1].Name = "Name";
            dataGridView.Columns[2].Name = "Grade";
            dataGridView.Columns[3].Name = "Age";
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Stop user interaction with the DataGridView
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersWidthSizeMode =  DataGridViewRowHeadersWidthSizeMode.DisableResizing;

        }

        // Insert into the database
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGrade.Text))
            {
                MessageBox.Show("Please enter a grade.");
                return;
            }
            // Validate that the date of birth is not in the future
            if (dobDateTimePicker.Value > DateTime.Now)
            {
                MessageBox.Show("Date of birth cannot be in the future.");
                return;
            }

            try
            {
                db.AddStudent(
                    txtName.Text,
                    txtGrade.Text,
                    dobDateTimePicker.Value.ToString("yyyy-MM-dd"));

                MessageBox.Show("Student Added");
                // Clear the text boxes
                txtName.Clear();
                txtGrade.Clear();
                dobDateTimePicker.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   ex.Message,
                   "Database Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }


        }

        // Load students from the database 
        private void btnLoadStudents_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.Rows.Clear();

                List<Student> students = db.GetStudents();
                foreach (Student student in students)
                {
                    dataGridView.Rows.Add(student.Id, student.Name, student.Grade, student.Age());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   ex.Message,
                   "Database Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
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
