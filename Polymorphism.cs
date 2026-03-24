Perform these actions and create a console app that includes the following:
using System; // Allows us to use basic system functions like Console

// Define an interface called IQuittable
// Interfaces only contain method signatures (no code inside)
interface IQuittable
{
    // Define a void method called Quit
    void Quit();
}

// Create a class called Employee
// The class inherits from the IQuittable interface using :
class Employee : IQuittable
{
    // Create properties for Employee
    public string Name { get; set; } // Employee name
    public int Id { get; set; } // Employee ID

    // Implement the Quit() method from the interface
    // Because Employee uses IQuittable, it MUST define this method
    public void Quit()
    {
        // Display a message when the employee quits
        Console.WriteLine(Name + " has quit the job.");
    }
}

// Main program class
class Program
{
    // Entry point of the console application
    static void Main(string[] args)
    {
        // Create an object of Employee
        Employee emp = new Employee();

        // Assign values to the employee properties
        emp.Name = "John";
        emp.Id = 1;

        // POLYMORPHISM:
        // Create an object of type IQuittable
        // Even though it's Employee, we treat it as IQuittable
        IQuittable quittableEmp = emp;

        // Call the Quit() method using the interface type
        quittableEmp.Quit();

        // Prevent console from closing immediately
        Console.ReadLine();
    }
}