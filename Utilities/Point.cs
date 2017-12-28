using System;
using System.Collections.Generic;

public class Point {
    public int X { get; }
    
    public int Y { get; }

    public int Length { get; }

    public int Value { get; set; }

    public InfectionStatus InfectionStatus { get; set;}

    public Point(int x, int y) {
        this.X = x;
        this.Y = y;
        this.Length = Math.Abs(x) + Math.Abs(y);
    }

    public Point(int x, int y, int value) {
        this.X = x;
        this.Y = y;
        this.Value = value;
    }

    public Point(int x, int y, InfectionStatus infectionStatus) {
        this.X = x;
        this.Y = y;
        this.InfectionStatus = infectionStatus;
    }

    public Point Up(bool invert) {
        return new Point(this.X, invert ? this.Y - 1 : this.Y + 1);
    }

    public Point Right(bool invert) {
        return new Point(this.X + 1, this.Y);
    }

    public Point Down(bool invert) {
        return new Point(this.X, invert ? this.Y + 1 : this.Y - 1);
    }

    public Point Left(bool invert) {
        return new Point(this.X - 1, this.Y);
    }

    public ValueTuple<int, int> ToTuple() => new ValueTuple<int, int>(this.X, this.Y);

    public override string ToString() => $"({this.X},{this.Y})";

    public List<Point> GetNeighbors(bool includeDiagonals = true) {
        var toReturn = new List<Point>();
        toReturn.Add(this.Move(Direction.Up));
        toReturn.Add(this.Move(Direction.Right));
        toReturn.Add(this.Move(Direction.Down));
        toReturn.Add(this.Move(Direction.Left));
        if(includeDiagonals) {
            toReturn.Add(this.Move(Direction.Up).Move(Direction.Right));
            toReturn.Add(this.Move(Direction.Up).Move(Direction.Left));
            toReturn.Add(this.Move(Direction.Down).Move(Direction.Right));
            toReturn.Add(this.Move(Direction.Down).Move(Direction.Left));
        }
        return toReturn;
    }

    public Point Move(Direction direction, bool invert = false) {
        switch(direction) {
            case Direction.Up:
                return this.Up(invert);
            case Direction.Right:
                return this.Right(invert);
            case Direction.Down:
                return this.Down(invert);
            case Direction.Left:
                return this.Left(invert);
            default:
                return this;
        }
    }
}