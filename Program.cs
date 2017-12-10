using System;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "192,69,168,160,78,1,166,28,0,83,198,2,254,255,41,12";
            Console.WriteLine($"Part 1: {Day10.Part1(256, input)}");
            Console.WriteLine($"Part 2: {Day10.Part2(256, input)}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
