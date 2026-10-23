using Microsoft.Data.Sqlite;

namespace LocalDB
{
    internal class DatabaseHelper
    {
        // Stores the connection string passed in from Form1
        // This tells SQLite where the database file is located
        private readonly string _connectionString;

        // Constructor
        // Runs when a DatabaseHelper object is created
        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Adds a new student record to the Students table
        public void AddStudent(string name, string grade)
        {
            // Create a connection to the database
            using var connection =
                new SqliteConnection(_connectionString);

            // Open the database connection
            connection.Open();

            // Create a SQL command object
            var command = connection.CreateCommand();

            // SQL statement to insert a new record
            command.CommandText =
                """
                INSERT INTO Students
                (
                    Name,
                    Grade
                )
                VALUES
                (
                    $name,
                    $grade
                );
                """;

            // Link the SQL parameter $name
            // to the name passed into the method
            // This is safer because it prevents SQL injection
            // and avoids problems with apostrophes in names such as O'Brian
            command.Parameters.AddWithValue(
                "$name",
                name);

            // Link the SQL parameter $grade
            // to the grade passed into the method
            command.Parameters.AddWithValue(
                "$grade",
                grade);

            // Execute the INSERT statement
            command.ExecuteNonQuery();
        }

        // Retrieves all students from the database
        // and returns them as a List<Student>
        public List<Student> GetStudents()
        {
            // Create an empty list ready to store Student objects
            List<Student> students =
                new List<Student>();

            // Create a connection to the database
            // This automatically disposes of the connection 
            // when the method finishes. 
            using var connection =
                new SqliteConnection(_connectionString);

            // Open the connection
            connection.Open();

            // Create the SQL command
            var command = connection.CreateCommand();

            // SQL query to retrieve all records
            command.CommandText =
                """
                SELECT *
                FROM Students;
                """;

            // Execute the query and store the results
            using var reader =
                command.ExecuteReader();

            // Loop through each row returned by the query
            while (reader.Read())
            {
                // Create a Student object from the current database row
                students.Add(
                    new Student(
                        reader.GetInt32(0),     // Id column
                        reader.GetString(1),    // Name column
                        reader.GetString(2)     // Grade column
                    ));
            }

            // Return the completed list of students
            return students;
        }
    }
}