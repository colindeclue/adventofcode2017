using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day24 {
    public static int Part1(string path) {
        var ports = ParseInput(path);
        var start = (0, 0);
        var bridge = new List<(int, int)>();
        var possibleBridges = BuildBridge(ports, bridge, 0);

        var byWeight = possibleBridges.OrderByDescending(b => b.TotalWeight()).ToList();

        return byWeight.First().TotalWeight();
    }

    public static int Part2(string path) {
        var ports = ParseInput(path);
        var start = (0, 0);
        var bridge = new List<(int, int)>();
        var possibleBridges = BuildBridge(ports, bridge, 0);

        var byLengthThenWeight = possibleBridges.OrderByDescending(b => b.Count()).ThenByDescending(b => b.TotalWeight()).ToList();
        var best = byLengthThenWeight.First();
        var second = byLengthThenWeight[1];

        return byLengthThenWeight.First().TotalWeight();
    }

    private static List<List<(int, int)>> BuildBridge(List<(int, int)> components, List<(int, int)> bridge, int openPort) {
        var nextSteps = GetPotentialMatches(components, openPort);
        if(nextSteps.Count == 0) {
            return new List<List<(int, int)>>{ bridge };
        }
        var output = new List<List<(int, int)>>();
        foreach(var possible in nextSteps) {
            var thisOpenPort = -1;
            if(openPort == possible.Item1) {
                thisOpenPort = possible.Item2;
            }
            else {
                thisOpenPort = possible.Item1;
            }
            var thisBridge = new List<(int, int)>(bridge);
            thisBridge.Add(possible);
            var thesePorts = components.Where(p => !p.Equals(possible)).ToList();
            output.AddRange(BuildBridge(thesePorts, thisBridge, thisOpenPort));
        }

        return output;
    }

    private static int TotalWeight(this List<(int, int)> bridge) {
        return bridge.Sum(p => p.Item1 + p.Item2);
    }

    private static List<(int, int)> ParseInput(string path) {
        var lines = File.ReadLines(path);
        var output = new List<(int, int)>();
        foreach(var line in lines) {
            var parts = line.Split('/');
            output.Add((int.Parse(parts[0]), int.Parse(parts[1])));
        }

        return output;
    }

    private static List<(int, int)> GetPotentialMatches(List<(int, int)> components, int openPort) {
        return components.Where(c => c.Item1 == openPort ||
                                c.Item2 == openPort)
                                .ToList();
    }
}