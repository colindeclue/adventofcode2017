using System;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Input/Day08.txt";
            var answer = Day08.DoAll(input);
            Console.WriteLine($"Part 1: {answer.endMax}");
            Console.WriteLine($"Part 2: {answer.globalMax}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
