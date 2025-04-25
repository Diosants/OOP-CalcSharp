using System;

public class Calculator
{
    public double Add(double x, double y)
    {
        return x + y;
    }

    public double Subtract(double x, double y)
    {
        return x - y;
    }

    public double Multiply(double x, double y)
    {
        if (x == 0 || y == 0)
        {
            throw new ArgumentException("Multiplication by zero is not allowed.");
        }
        return x * y;

    }

    public double Divide(double x, double y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        return x / y;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        Console.WriteLine("=== Simple OOP Calculator ===");

        Console.WriteLine("Enter the First Number, please \n");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the second Number");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Choose operation (+, -, *, /):");
        string? operation = Console.ReadLine(); // Allow operation to be nullable
        double result = 0;
        bool validOperation = true;

        try
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation), "Operation cannot be null.");
            }

            switch (operation)
            {
                case "+":
                    result = calculator.Add(num1, num2);
                    break;
                case "-":
                    result = calculator.Subtract(num1, num2);
                    break;
                case "*":
                    result = calculator.Multiply(num1, num2);
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    result = calculator.Divide(num1, num2);
                    break;
                default:
                    validOperation = false;
                    Console.WriteLine("Invalid operation. Please use +, -, *, or /.");
                    break;
            }
            if (validOperation)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {result}");
                Console.ResetColor();
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
        catch (DivideByZeroException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Thank you for using the calculator!");
            Console.WriteLine("You're The best!");
            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }
    }
}





