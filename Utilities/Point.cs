using System;
using System.Collections.Generic;

public class Point {
    public int X { get; }
    
    public int Y { get; }

    public int Length { get; }

    public int Value { get; set; }

    public Point(int x, int y) {
        this.X = x;
        this.Y = y;
        this.Length = Math.Abs(x) + Math.Abs(y);
    }

    public Point Up() {
        return new Point(this.X, this.Y + 1);
    }

    public Point Right() {
        return new Point(this.X + 1, this.Y);
    }

    public Point Down() {
        return new Point(this.X, this.Y - 1);
    }

    public Point Left() {
        return new Point(this.X - 1, this.Y);
    }

    public ValueTuple<int, int> ToTuple() => new ValueTuple<int, int>(this.X, this.Y);

    public override string ToString() => $"({this.X},{this.Y})";

    public List<Point> GetNeighbors() {
        var toReturn = new List<Point>();
        toReturn.Add(this.Move(Direction.Up));
        toReturn.Add(this.Move(Direction.Right));
        toReturn.Add(this.Move(Direction.Down));
        toReturn.Add(this.Move(Direction.Left));
        toReturn.Add(this.Move(Direction.Up).Move(Direction.Right));
        toReturn.Add(this.Move(Direction.Up).Move(Direction.Left));
        toReturn.Add(this.Move(Direction.Down).Move(Direction.Right));
        toReturn.Add(this.Move(Direction.Down).Move(Direction.Left));
        return toReturn;
    }

    public Point Move(Direction direction) {
        switch(direction) {
            case Direction.Up:
                return this.Up();
            case Direction.Right:
                return this.Right();
            case Direction.Down:
                return this.Down();
            case Direction.Left:
                return this.Left();
            default:
                return this;
        }
    }
}