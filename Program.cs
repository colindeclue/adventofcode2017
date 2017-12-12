using System;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Input/Day12.txt";
            Console.WriteLine($"Part 1: {Day12.Part1(input)}");
            Console.WriteLine($"Part 2: {Day12.Part2(input)}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
