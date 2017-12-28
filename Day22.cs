using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day22 {
    public static int Part1(string path, int count) {
        var grid = BuildStart(path);
        Print(grid, 25, new Point(0, 0));
        var infectionCount = 0;
        var current = grid[(0, 0)];
        var direction = Direction.Up;
        for(int i = 0; i < count; i++) {
            if(current.InfectionStatus == InfectionStatus.Infected) {
                // infected
                direction = TurnRight(direction);
                current.InfectionStatus = InfectionStatus.Clean;
            }
            else {
                // clean
                direction = TurnLeft(direction);
                current.InfectionStatus = InfectionStatus.Infected;
                infectionCount++;
            }

            var next = current.Move(direction, true);
            var key = next.ToTuple();
            if(grid.ContainsKey(key)) {
                next = grid[key];
            }
            else {
                next.Value = 0;
                grid[key] = next;
            }

            current = next;
            // Print(grid, 8, current);
        }

        return infectionCount;
    }

    public static int Part2(string path, int count) {
        var grid = BuildStart(path);
        Print(grid, 25, new Point(0, 0));
        var infectionCount = 0;
        var current = grid[(0, 0)];
        var direction = Direction.Up;
        for(int i = 0; i < count; i++) {
            switch(current.InfectionStatus) {
                case InfectionStatus.Clean:
                    direction = TurnLeft(direction);
                    current.InfectionStatus = InfectionStatus.Weakened;
                    break;
                case InfectionStatus.Flagged:
                    current.InfectionStatus = InfectionStatus.Clean;
                    direction = Reverse(direction);
                    break;
                case InfectionStatus.Weakened:
                    current.InfectionStatus = InfectionStatus.Infected;
                    infectionCount++;
                    break;
                case InfectionStatus.Infected:
                    current.InfectionStatus = InfectionStatus.Flagged;
                    direction = TurnRight(direction);
                    break;                    
            }

            var next = current.Move(direction, true);
            var key = next.ToTuple();
            if(grid.ContainsKey(key)) {
                next = grid[key];
            }
            else {
                next.Value = 0;
                grid[key] = next;
            }

            current = next;
            // Print(grid, 8, current);
        }

        return infectionCount;
    }

    private static void Print(Dictionary<(int, int), Point> grid, int size, Point current) {
        for(int i = -(size / 2); i <= size/2; i++) {
            for(int j = -(size/2); j <= size/2; j++) {
                var key = (j, i);
                if(grid.ContainsKey(key)) {
                    var point = grid[(j, i)];
                    var nodeValue = "";
                    switch(point.InfectionStatus) {
                        case InfectionStatus.Clean:
                            nodeValue = ".";
                            break;
                        case InfectionStatus.Flagged:
                            nodeValue = "F";
                            break;
                        case InfectionStatus.Infected:
                            nodeValue = "#";
                            break;
                        case InfectionStatus.Weakened:
                            nodeValue = "W";
                            break;
                        default:
                            nodeValue = ".";
                            break;
                    }
                    var toPrint = $" {nodeValue} ";
                    if(key.Equals(current.ToTuple())) {
                        toPrint = $"[{nodeValue}]";
                    }
                    Console.Write(toPrint);
                } else {
                    Console.Write(" . ");
                }
            }
            Console.Write('\n');
        }
    }

    private static Direction TurnLeft(Direction current) {
        switch(current) {
            case Direction.Up:
                return Direction.Left;
            case Direction.Right:
                return Direction.Up;
            case Direction.Down:
                return Direction.Right;
            case Direction.Left:
                return Direction.Down;
            default:
                return current;
        }
    }

    private static Direction Reverse(Direction current) {
        switch(current) {
            case Direction.Up:
                return Direction.Down;
            case Direction.Right:
                return Direction.Left;
            case Direction.Down:
                return Direction.Up;
            case Direction.Left:
                return Direction.Right;
            default:
                return current;
        }
    }

    private static Direction TurnRight(Direction current) {
        switch(current) {
            case Direction.Up:
                return Direction.Right;
            case Direction.Right:
                return Direction.Down;
            case Direction.Down:
                return Direction.Left;
            case Direction.Left:
                return Direction.Up;
            default:
                return current;
        }
    }

    private static Dictionary<(int x, int y), Point> BuildStart(string path) {
        var grid = new Dictionary<(int x, int y), Point>();
        var lines = File.ReadLines(path).ToList();
        for(int i = 0; i < lines.Count; i++) {
            var line = lines[i];
            for(int j = 0; j < line.Count(); j++) {
                var x = (j - (line.Count() / 2));
                var y = (i - (lines.Count() / 2));
                // 0 is clean, -1 is infected
                var thisPoint = new Point(x, y, line[j] == '.' ? InfectionStatus.Clean : InfectionStatus.Infected);
                grid.Add(thisPoint.ToTuple(), thisPoint);
            }
        }

        return grid;
    }
}