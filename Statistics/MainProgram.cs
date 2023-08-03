using System;


namespace Statistics
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            NumberCruncher test = new NumberCruncher();

            test.AddNumber(5);
            test.AddNumber(10);
            test.AddNumber(50);
            test.AddNumber(500);
            test.AddNumber(149);
            test.AddNumber(10);
            test.AddNumber(50);
            test.AddNumber(1000);

            test.DisplayData();

            Console.WriteLine();

            Console.WriteLine($"Count: {test.count}");
            Console.WriteLine($"Total: {test.Total()}");
            Console.WriteLine($"Average: {test.Average()}");
            Console.WriteLine($"Minimum: {test.Minimum()}");
            Console.WriteLine($"Maximum: {test.Maximum()}");
            Console.WriteLine($"Range: {test.Range()}");

            Console.WriteLine();
            Console.WriteLine();

            test.RemoveLastNumber();
            test.RemoveNumberAt(4);
            test.DisplayData();

            Console.WriteLine();

            Console.WriteLine($"Count: {test.count}");
            Console.WriteLine($"Total: {test.Total()}");   
            Console.WriteLine($"Average: {test.Average()}");    
            Console.WriteLine($"Minimum: {test.Minimum()}");    
            Console.WriteLine($"Maximum: {test.Maximum()}");
            Console.WriteLine($"Range: {test.Range()}");

            Console.WriteLine($"The most frequent number/s: ");
            foreach (double number in test.Mode())
            {  Console.Write($"{number} "); }

            Console.ReadLine();
        }
    }
}
