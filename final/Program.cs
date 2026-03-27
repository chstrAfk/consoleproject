using System;
using System.Data.Entity;

namespace StudentCodeFirstApp
{
    // This class represents a student in the database
    public class Student
    {
        // Primary key
        public int StudentId { get; set; }

        // Student first name
        public string FirstName { get; set; }

        // Student last name
        public string LastName { get; set; }
    }

    // This class connects to the database
    public class StudentContext : DbContext
    {
        // This tells Entity Framework which connection string to use
        public StudentContext() : base("StudentContext")
        {
        }

        // This will become the Students table in the database
        public DbSet<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new student object
            Student student = new Student()
            {
                FirstName = "Ashley",
                LastName = "Revilla"
            };

            // Open database connection
            using (StudentContext db = new StudentContext())
            {
                // Add the student to the table
                db.Students.Add(student);

                // Save changes to the database
                db.SaveChanges();
            }

            // Show success message
            Console.WriteLine("One student was added to the database.");

            // Keep console open
            Console.ReadLine();
        }
    }
}