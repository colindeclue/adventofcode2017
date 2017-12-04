using System;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "Input/Day04.txt";
            Console.WriteLine($"Part 1: {Day04.Part1(path)}");
            Console.WriteLine($"Part 2: {Day04.Part2(path)}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
