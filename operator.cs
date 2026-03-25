using System; // Allows us to use Console and other basic system functions

// Define a class named Employee
public class Employee
{
    // Property for Employee ID
    public int Id { get; set; }

    // Property for Employee First Name
    public string FirstName { get; set; }

    // Property for Employee Last Name
    public string LastName { get; set; }

    // Overload the == operator to compare two Employee objects
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        // If both objects are null, return true
        if (ReferenceEquals(emp1, emp2))
        {
            return true;
        }

        // If one is null and the other is not, return false
        if (emp1 is null || emp2 is null)
        {
            return false;
        }

        // Compare employees based on their Id property
        return emp1.Id == emp2.Id;
    }

    // Overload the != operator (must be done when overloading ==)
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        // Return the opposite of the == operator
        return !(emp1 == emp2);
    }

    // Override Equals method (good practice when overloading operators)
    public override bool Equals(object obj)
    {
        // Check if the object is an Employee
        if (obj is Employee other)
        {
            // Compare Ids
            return this.Id == other.Id;
        }

        return false;
    }

    // Override GetHashCode method (required when overriding Equals)
    public override int GetHashCode()
    {
        return Id.GetHashCode(); // Use Id for hash code
    }
}

// Main program class
class Program
{
    // Entry point of the console application
    static void Main(string[] args)
    {
        // Create first Employee object
        Employee emp1 = new Employee();
        emp1.Id = 1; // Assign Id
        emp1.FirstName = "John"; // Assign First Name
        emp1.LastName = "Doe"; // Assign Last Name

        // Create second Employee object
        Employee emp2 = new Employee();
        emp2.Id = 1; // Same Id as emp1 (so they should be equal)
        emp2.FirstName = "Jane"; // Different First Name
        emp2.LastName = "Smith"; // Different Last Name

        // Compare the two Employee objects using overloaded ==
        bool areEqual = emp1 == emp2;

        // Display the result of the comparison
        Console.WriteLine("Are employees equal (==)? " + areEqual);

        // Compare using != operator
        bool areNotEqual = emp1 != emp2;

        // Display result of != comparison
        Console.WriteLine("Are employees NOT equal (!=)? " + areNotEqual);

        // Keep console open until user presses Enter
        Console.ReadLine();
    }
}