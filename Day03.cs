using System;
using System.Collections.Generic;

public static class Day03 {

    public static int Part1(int input) {
        var dict = new Dictionary<ValueTuple<int, int>, Point>();
        var start = new Point(0,0);
        dict[start.ToTuple()] = start;

        var currentDirection = Direction.Right;
        for(int i = 1; i < input; i++) {
            var result = DoStep(currentDirection, start, dict);
            start = result.Item1;
            currentDirection = result.Item2;
        }

        return start.Length;
    }

    public static int Part2(int input) {
        var dict = new Dictionary<ValueTuple<int, int>, Point>();
        var start = new Point(0,0);
        dict[start.ToTuple()] = start;
        start.Value = 1;

        var currentDirection = Direction.Right;
        for(int i = 1; i < input; i++) {
            var result = DoStep(currentDirection, start, dict);
            start = result.Item1;
            currentDirection = result.Item2;
            var neighbors = start.GetNeighbors();
            var value = 0;
            foreach(var point in neighbors) {
                if(dict.ContainsKey(point.ToTuple())) {
                    value += dict[point.ToTuple()].Value;
                }
            }

            start.Value = value;

            if(value > input) {
                return value;
            }
        }

        return -1;
    }

    private static ValueTuple<Point, Direction> DoStep(Direction currentDirection, Point start, Dictionary<ValueTuple<int, int>, Point> dict) {
        start = start.Move(currentDirection);
        dict.Add(start.ToTuple(), start);
        var nextDirection = NextDirection(currentDirection);
        var next = start.Move(nextDirection);
        if(!dict.ContainsKey(next.ToTuple())) {
            currentDirection = nextDirection;
        }

        return new ValueTuple<Point, Direction>(start, currentDirection);
    }

    private static Direction NextDirection(Direction direction) {
        switch(direction) {
            case Direction.Up:
                return Direction.Left;
            case Direction.Right:
                return Direction.Up;
            case Direction.Left:
                return Direction.Down;
            case Direction.Down:
                return Direction.Right;
            default:
                return direction;
        }
    }
}