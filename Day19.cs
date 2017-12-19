using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Day19 {
    public static (string foundLetters, int stepCount) Part1(string path) {
        var lines = File.ReadLines(path).ToList();
        var maze = ParseInput(lines);
        var direction = Direction.Down;
        var foundLetters = new StringBuilder();
        var y = 0;
        var x = lines.First().IndexOf('|');
        var currentPoint = new Point(x, y);
        var stepCount = 0;
        while(true) {
            stepCount++;
            currentPoint = currentPoint.Move(direction);
            if(!maze.ContainsKey(currentPoint.ToTuple())) {
                return (foundLetters: foundLetters.ToString(), stepCount: stepCount);
            }

            var nextCharacter = maze[currentPoint.ToTuple()];
            var continueChar = direction == Direction.Up || direction == Direction.Down ? '|' : '-';
            switch(nextCharacter) {
                case ' ':
                    return (foundLetters: foundLetters.ToString(), stepCount: stepCount);
                case '|':
                case '-':
                    continue;
                case '+':
                    if(direction == Direction.Up || direction == Direction.Down) {
                        var left = currentPoint.Move(Direction.Left);
                        if(maze.ContainsKey(left.ToTuple()) && maze[left.ToTuple()] != ' ') {
                            direction = Direction.Left;
                        }
                        else {
                            direction = Direction.Right;
                        }
                    }
                    else {
                        var up = currentPoint.Move(Direction.Up);
                        if(maze.ContainsKey(up.ToTuple()) && maze[up.ToTuple()] != ' ') {
                            direction = Direction.Up;
                        }
                        else {
                            direction = Direction.Down;
                        }
                    }
                    break;
                default:
                    foundLetters.Append(nextCharacter);
                    break;
            }
        }
    }

    private static Dictionary<ValueTuple<int, int>, char> ParseInput(List<string> lines) {
        var maze = new Dictionary<ValueTuple<int, int>, char>();
        var altCount = 0;
        for(var y = 0; y < lines.Count; y++) {
            var line = lines[y];
            for(var x = 0; x < line.Length; x++) {
                var point = new ValueTuple<int, int>(x, -y);
                maze[point] = line[x];
                if(line[x] != ' ') {
                    altCount++;
                }
            }
        }
        Console.WriteLine(altCount);
        return maze;
    }
}