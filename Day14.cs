using System;
using System.Collections.Generic;
using System.Linq;

public static class Day14 {
    public static int Part1(string input) {
        var grid = GetGrid(input);

        return grid.Count(l => l.Value.Value == 1);
    }

    public static int Part2(string input) {
        var grid = GetGrid(input);
        var groups = new List<Dictionary<ValueTuple<int, int>, int>>();
        var pointsToCheck = new HashSet<ValueTuple<int, int>>();

        for(int i = 0; i < 128; i++) {
            for(int j = 0; j < 128; j++) {
                pointsToCheck.Add(new ValueTuple<int, int>(i, j));
                
            }
        }
        var groupCount = 0;
        while(pointsToCheck.Any()) {
            var tuple = pointsToCheck.First();
            var point = grid[tuple];
            if(point.Value != 0) {
                groupCount++;
                ClearNeighbors(grid, pointsToCheck, point);
            }
            else {
                pointsToCheck.Remove(tuple);
            }
        }

        return groupCount;
    }

    private static void ClearNeighbors(Dictionary<ValueTuple<int, int>, Point> grid, HashSet<ValueTuple<int, int>> pointsToCheck, Point current) {
        if(pointsToCheck.Contains(current.ToTuple())) {
            pointsToCheck.Remove(current.ToTuple());
            var neighbors = current.GetNeighbors(false).Where(p => grid.ContainsKey(p.ToTuple())).Select(p => grid[p.ToTuple()]).Where(p => p.Value != 0).ToList();
            neighbors.ForEach(p => ClearNeighbors(grid, pointsToCheck, p));
        }

    }

    private static Dictionary<ValueTuple<int, int>, Point> GetGrid(string input) {
        var grid = new Dictionary<ValueTuple<int, int>, Point>();
        var standardAddition = new int[] {17, 31, 73, 47, 23};
        for(int i = 0; i < 128; i++) {
            var part = input + "-" + i;
            var lengths = part.Select(c => (int)Convert.ToByte(c)).Concat(standardAddition).ToArray();
            var runner = new KnotRunner(256, lengths);

            var result = runner.GetResult().SelectMany(k => Convert.ToString(k, 2).PadLeft(8, '0').Select(c => c == '0' ? 0 : 1)).ToList();
            for(var j = 0; j < result.Count(); j++) {
                grid.Add(new ValueTuple<int, int>(i, j), new Point(i, j, result[j]));
            }
        }

        return grid;
    }
}