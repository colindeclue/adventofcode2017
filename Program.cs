using System;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "Input/Day02.txt";
            Console.WriteLine($"Part 1: {Day02.Part1(path)}");
            Console.WriteLine($"Part 2: {Day02.Part2(path)}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
