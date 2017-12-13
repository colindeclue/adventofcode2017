using System;
using System.IO;
using System.Linq;

public static class Day13 {
    public static int Part1(string path) {
        var scanners = File.ReadLines(path)
            .Select(l => l.Trim())
            .Skip(1)
            .Where(l => !string.IsNullOrEmpty(l))
            .Select(l => l.Split(':').Select(p => int.Parse(p)).ToArray())
            .Where(s => s[0] % ((s[1] * 2) - 2) == 0);
        
        return scanners.Sum(s => s[0] * s[1]);
    }

    public static int Part2(string path) {
        var scanners = File.ReadLines(path)
            .Select(l => l.Trim().Split(':').Select(p => int.Parse(p.Trim())).ToArray())
            .ToArray();
        
        var delay = 0;
        while(scanners.Any(s => (s[0] + delay) % ((s[1] * 2) - 2) == 0)) delay++;

        return delay;
    }
}