using System;

namespace _2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[]{4,1,15,12,0,9,9,5,5,8,7,3,14,5,12,3};
            // var input = new[]{2,4,1,2};
            
            Console.WriteLine($"Part 1: {Day06.Part1(input)}");
            Console.WriteLine($"Part 2: {Day06.Part2(input)}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
