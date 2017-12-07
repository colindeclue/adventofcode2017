using System;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Input/Day07.txt";
            // var input = new[]{2,4,1,2};
            
            Console.WriteLine($"Part 1: {Day07.Part1(input)}");
            Console.WriteLine($"Part 2: {Day07.Part2(input)}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
