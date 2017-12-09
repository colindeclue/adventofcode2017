using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Day09 {
    public static int Part1(string path) {
        var input = File.ReadLines(path).First();
        var regex = new Regex(@"!.");
        var garbageRegex = new Regex(@"<[^>]*>");
        var step = regex.Replace(input, string.Empty);
        step = garbageRegex.Replace(step, string.Empty);
        var score = 0;
        var currentValue = 0;
        foreach(var part in step) {
            if(part == '{') {
                currentValue++;
            }
            if(part == '}') {
                score += currentValue;
                currentValue--;
            }

        }

        return score;
    }

    public static int Part2(string path) {
        var input = File.ReadLines(path).First();
        var regex = new Regex(@"!.");
        var garbageRegex = new Regex(@"<[^>]*>");
        var step = regex.Replace(input, string.Empty);
        return garbageRegex.Matches(step).Cast<Match>().Select(m => m.Value).Select(s => s.Length - 2).Sum();
    }
}