using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // Create a class named MathClass
    class MathClass
    {
        // Create a void method that takes two integers as parameters
        // The method performs a math operation on the first integer
        // and displays the second integer
        public void DoMath(int num1, int num2)
        {
            // Perform a math operation on the first integer (example: multiply by 2)
            int result = num1 * 2;

            // Display the result of the math operation
            Console.WriteLine("Result of first number * 2: " + result);

            // Display the second integer
            Console.WriteLine("Second number is: " + num2);
        }
    }

    // Main program class
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate (create an object of) the MathClass
            MathClass mathObject = new MathClass();

            // Call the method and pass two numbers normally
            mathObject.DoMath(5, 10);

            // Call the method again, but this time specify parameters by name
            mathObject.DoMath(num1: 7, num2: 20);

            // Prevent the console from closing immediately
            Console.ReadLine();
        }
    }
}