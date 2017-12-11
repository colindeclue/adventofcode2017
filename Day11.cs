using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day11 {
    public static (int finalDistance, int maxDistance) DoAll(string path) {
        var input = File.ReadAllLines(path).First();
        var currentList = new List<string>();
        var steps = input.Split(',');
        var maxLength = int.MinValue;
        foreach(var step in steps) {
            if(currentList.Count > maxLength) {
                maxLength = currentList.Count;
            }
            var opposite = Opposites[step];
            if(currentList.Contains(opposite)) {
                currentList.Remove(opposite);
            }
            else {
                var combos = Combo[step];
                var found = false;
                foreach(var combo in combos.Split(';')) {
                    var pairs = combo.Split(',');
                    if(currentList.Contains(pairs[0])) {
                        currentList.Remove(pairs[0]);
                        currentList.Add(pairs[1]);
                        found = true;
                        break;
                    }
                }

                if(!found) {
                    currentList.Add(step);
                }
            }
        }

        return (finalDistance: currentList.Count, maxDistance: maxLength);
    }

    private static Dictionary<string, string> Opposites = new Dictionary<string, string>{
        {"n","s"},
        {"s","n"},
        {"nw","se"},
        {"se","nw"},
        {"sw","ne"},
        {"ne","sw"}
    };

    private static Dictionary<string, string> Combo = new Dictionary<string, string>{
        {"n","sw,nw;se,ne"},
        {"s","nw,sw;ne,se"},
        {"nw","s,sw;ne,n"},
        {"ne","s,se;nw,n"},
        {"sw","n,nw;se,s"},
        {"se","n,ne;sw,s"}
    };
}