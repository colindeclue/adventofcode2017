using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day02 {
    public static int Part1(string path) {
        var lines = GetLines(path);
        var diffSum = 0;
        foreach(var line in lines) {
            var localMin = int.MaxValue;
            var localMax = int.MinValue;
            foreach(var num in line) {
                if(num < localMin) {
                    localMin = num;
                }
                if(num > localMax) {
                    localMax = num;
                }
            }

            diffSum += localMax - localMin;
        }

        return diffSum;
    }

    public static int Part2(string path) {
        var lines = GetLines(path);
        var divSum = 0;
        foreach(var line in lines) {
            foreach(var num in line) {
                var divisor = line.FirstOrDefault(o => (o != num) && (o % num == 0 || num % o == 0));
                if(divisor == 0) {
                    continue;
                }

                divSum += (num > divisor) ? num / divisor : divisor / num;
                break;
            }
        }

        return divSum;
    }

    private static List<List<int>> GetLines(string path) {
        var lines = File.ReadAllLines(path);
        return lines.Select(l => l.Split().Select(int.Parse).ToList()).ToList();
    }
}