using System.Drawing;

namespace DebuggingExamples;

class DebuggingExamples
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an example to run:");
            Console.WriteLine("1 - Factorial recursion");
            Console.WriteLine("2 - Reference vs value types");
            Console.WriteLine("3 - List population bug");
            Console.WriteLine("4 - Null reference bug");
            Console.WriteLine("5 - Integer division logic bug");
            Console.WriteLine("6 - Collection modification bug");
            Console.WriteLine("0 - Exit");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    example1();
                    break;
                case "2":
                    example2();
                    break;
                case "3":
                    example3();
                    break;
                case "4":
                    example4();
                    break;
                case "5":
                    example5();
                    break;
                case "6":
                    example6();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void example1()
    {
        // Goal: Use Call Stack to diagnose runaway recursion.
        // Symptom: StackOverflowException when factorial is called with a negative number.
        // Observe in debugger: repeated CalculateFactorial frames and n decreasing forever.
        int positiveNumber = 5;
        int negativeNumber = -5;

        Console.WriteLine($"Factorial of {positiveNumber}: {CalculateFactorial(positiveNumber)}");
        Console.WriteLine($"Factorial of {negativeNumber}: {CalculateFactorial(negativeNumber)}");
    }

    static void example2()
    {
        // Goal: Compare reference-type copying with value-type copying.
        // Symptom: No exception; changing pen2 affects pen1, but changing point2 does not affect point1.
        // Observe in debugger: Pen variables point to the same object, while Point variables hold separate copies.

        Pen pen1 = new Pen(Color.Black);
        Pen pen2 = pen1;
        pen2.Color = Color.Blue;
        Console.WriteLine(pen1.Color);     
        Console.WriteLine(pen2.Color);

        Point point1 = new Point(20, 30);
        Point point2 = point1;
        point2.X = 50;
        Console.WriteLine(point1.X);
        Console.WriteLine(point2.X);
    }

    static void example3()
    {
        // Goal: Use exception breakpoints and Locals to diagnose invalid list access.
        // Symptom: ArgumentOutOfRangeException at values[i] = i.
        // Observe in debugger: values.Count stays 0, so indexed assignment has nowhere to write.

        List<int> values = new List<int>();

        List<int> otherValues = new List<int> { 10, 20, 30, 40, 50 };
        Console.WriteLine("Hello");

        Console.WriteLine("Values in 'values' list:");

        for (int i=0; i<=4; i++)
        {
            values[i] = i;
        }

        for (int i=0; i<=4; i++)
        {
            otherValues[i] = values[i];
        }

    }

    static void example4()
    {
        // Goal: Use Exception Helper and Call Stack to find the real source of a null reference.
        // Symptom: NullReferenceException when printing the student's city.
        // Observe in debugger: student is not null, but student.Address is null after returning from LoadStudent(false).
        Student student = LoadStudent(false);
        Console.WriteLine($"Student city: {student.Address!.City}");
    }

    static void example5()
    {
        // Goal: Use Watch or Locals to find a logic bug caused by integer division.
        // Symptom: Program runs, but prints 0% instead of 70%.
        // Observe in debugger: completedTasks / totalTasks is evaluated as integer 0 before being assigned to double.
        int completedTasks = 7;
        int totalTasks = 10;

        double progress = completedTasks / totalTasks * 100;

        Console.WriteLine($"Progress: {progress}%");
    }

    static void example6()
    {
        // Goal: Use exception breakpoints and a conditional breakpoint to catch collection modification during iteration.
        // Symptom: InvalidOperationException when removing items from a list inside foreach.
        // Observe in debugger: the current value of number, the list contents, and the moment the collection changes during enumeration.
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                numbers.Remove(number);
            }
        }

        Console.WriteLine(string.Join(", ", numbers));
    }

    static Student LoadStudent(bool withAddress)
    {
        Student student = new Student { Name = "Ana" };

        if (withAddress)
        {
            student.Address = new Address { City = "Sarajevo" };
        }

        return student;
    }

    static int CalculateFactorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * CalculateFactorial(n - 1);
        }
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {

        }
    }

    public class Pen
    {
        public Color Color { get; set; }

        public Pen(Color color)
        {
            Color = color;
        }
        
        public Pen()
        {

        }
    }

    class MyObject
    {
        public int Value { get; }

        public MyObject(int value)
        {
            Value = value;
        }
    }

    class Student
    {
        public string Name { get; set; } = "";
        public Address? Address { get; set; }
    }

    class Address
    {
        public string City { get; set; } = "";
    }

}
