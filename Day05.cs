using System.IO;
using System.Linq;

public static class Day05 {
    public static int Part1(string path) {
        var instructions = GetArray(path);
        return DoDay05(instructions, false);
    }

    public static int Part2(string path) {
        var instructions = GetArray(path);
        return DoDay05(instructions, true);
    }

    private static int[] GetArray(string input) {
        var lines = File.ReadLines(input);
        return lines.Select(i => int.Parse(i)).ToArray();
    }

    private static int DoDay05(int[] instructions, bool part2) {
        var steps = 0;
        for(int i = 0; i < instructions.Length && i >= 0;) {
            var current = instructions[i];
            if(current >= 3 && part2) {
                instructions[i]--;
            }
            else {
                instructions[i]++;
            }
            i += current;
            steps++;
        }

        return steps;
    }
}