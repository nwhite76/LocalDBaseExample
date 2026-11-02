using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDB
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Dob { get; set; }
        public Student(int id, string name, string grade, string dob)
        {
            Id = id;
            Name = name;
            Grade = grade;
            Dob = dob;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Grade}";
        }

        public int Age()
        {
            // Calculate student age
            DateTime dob = DateTime.Parse(Dob);
            int age = DateTime.Today.Year - dob.Year;
            if (dob > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
