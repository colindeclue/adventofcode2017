using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Day07 {
    public static string Part1(string path) {
        var lines = File.ReadLines(path);
        var nodeDictionary = GetNodes(lines);

        // Now just find the node with no parents.
        return nodeDictionary.Values.FirstOrDefault(n => n.ParentNode == null).Name;
    }

    public static int Part2(string path) {
        var lines = File.ReadLines(path);
        var nodeDictionary = GetNodes(lines);

        var highestUnbalanced = nodeDictionary.Values.Where(n => !n.IsBalanced()).OrderByDescending(n => n.Depth()).FirstOrDefault();

        var byChildWeight = highestUnbalanced.ChildNodes.OrderByDescending(c => c.TotalWeight()).ToList();
        // assume 3 childWeights
        if(byChildWeight[0].TotalWeight() > byChildWeight[1].TotalWeight()) {
            // first one weighs too much
            return byChildWeight[0].Weight - (byChildWeight[0].TotalWeight() - byChildWeight[1].TotalWeight());
        }
        else if(byChildWeight[2].TotalWeight() < byChildWeight[1].TotalWeight()) {
            // last one weighs too little
            return byChildWeight[2].Weight + (byChildWeight[1].TotalWeight() - byChildWeight[2].TotalWeight());
        }
        return -1;
        // var childWeights = highestUnbalanced.ChildNodes.Select(c => c.TotalWeight())

        // return highestUnbalanced;
    }

    private static Dictionary<string, Node> GetNodes(IEnumerable<string> lines) {
        var nodeDictionary = new Dictionary<string, Node>();
        // First we loop through and add the nodes to the dictionary
        var nameAndWeightRegex = new Regex(@"(?<name>\w+) \((?<weight>\d+)\)");
        foreach(var line in lines) {
            var matches = nameAndWeightRegex.Matches(line);
            var name = matches[0].Groups["name"].Value;
            var weight = matches[0].Groups["weight"].Value;
            var node = new Node(name, int.Parse(weight));
            nodeDictionary.Add(name, node);
        }

        // Next we loop through again to assign parents/children
        foreach(var line in lines) {
            // Only work with lines with 
            if(!line.Contains("->")) {
                continue;
            }

            var matches = nameAndWeightRegex.Matches(line);
            var name = matches[0].Groups["name"].Value;
            var parts = line.Split(new [] { "->" }, StringSplitOptions.None);
            var children = parts[1].Split(',').Select(s => s.Trim());
            var parentNode = nodeDictionary[name];
            foreach(var child in children) {
                var childNode = nodeDictionary[child];
                parentNode.ChildNodes.Add(childNode);
                childNode.ParentNode = parentNode;
            }
        }

        return nodeDictionary;
    }
}