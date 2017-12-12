using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day12 {
    public static int Part1(string path) {
        var nodes = BuildNodes(path);
        var group = nodes["0"].FindGroup();

        return group.Count();
    }

    private static Dictionary<string, ProgramNode> BuildNodes(string path) {
        var lines = File.ReadAllLines(path);
        var nodes = lines.Select(l => new ProgramNode(l.Split()[0])).ToDictionary(n => n.Id, n => n);
        foreach(var line in lines) {
            var parts = line.Split();
            var keys = parts.Skip(2).Select(s => s.Trim().TrimEnd(','));
            var thisNode = nodes[parts[0]];
            var childNodes = keys.Select(id => nodes[id]);
            thisNode.Connections.AddRange(childNodes);
        }

        return nodes;
    }

    public static int Part2(string path) {
        var nodes = BuildNodes(path);
        var groups = new List<Dictionary<string, ProgramNode>>();
        foreach(var node in nodes.Values) {
            if(!groups.Any(d => d.ContainsKey(node.Id))) {
                groups.Add(node.FindGroup());
            }
        }

        return groups.Count();
    }
}