using System;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Input/Day11.txt";
            Console.WriteLine($"Part 1: {Day11.DoAll(input).finalDistance}");
            Console.WriteLine($"Part 2: {Day11.DoAll(input).maxDistance}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
