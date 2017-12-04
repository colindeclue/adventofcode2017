using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day04 {
    public static int Part1(string input) {
        return DoDay04(input, false);
    }

    public static int Part2(string input) {
        return DoDay04(input, true);
    }

    private static int DoDay04(string input, bool part2) {
        var lines = File.ReadLines(input);
        int validCount = 0;
        foreach(var line in lines) {
            var parts = line.Split();
            var valid = true;
            HashSet<string> set = new HashSet<string>();
            foreach(var part in parts) {
                var thisPart = part2 ? string.Concat(part.OrderBy(c => c)) : part;
                if(set.Contains(thisPart)) {
                    valid = false;
                    break;
                }
                set.Add(thisPart);
            }
            if(valid) {
                validCount++;
            }
        }

        return validCount;
    }
}