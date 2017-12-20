using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Day20 {
    public static int Part1(string path) {
        var lines = File.ReadLines(path).ToList();
        var vectors = ParseInput(lines);
        var lastMinVector = -1;
        var ticksRun = 0;
        var sinceLastChange = 0;
        while(true) {
            if(sinceLastChange > 500) {
                break;
            }
            long minDistance = long.MaxValue;
            var minVectorId = -1;
            foreach(var vector in vectors) {
                var newDistance = vector.Tick();
                if(newDistance < minDistance) {
                    minDistance = newDistance;
                    minVectorId = vector.Id;
                }
            }
            if(minVectorId != lastMinVector) {
                lastMinVector = minVectorId;
            }
            else {
                sinceLastChange++;
            }
            ticksRun++;
        }

        return lastMinVector;
    }

    public static int Part2(string path) {
        var lines = File.ReadLines(path).ToList();
        var vectors = ParseInput(lines);
        var ticksRun = 0;
        var sinceLastCollision = 0;
        while(true) {
            if(sinceLastCollision > 500) {
                break;
            }
            var potentialCollisions = new Dictionary<(long, long, long), List<Vector>>();
            var collisions = new List<List<Vector>>();
            var hadCollision = false;
            foreach(var vector in vectors) {
                vector.Tick();
                var newPosition = vector.ToTuple();
                if(potentialCollisions.ContainsKey(newPosition)) {
                    hadCollision = true;
                    collisions.Add(potentialCollisions[newPosition]);
                }
                else {
                    potentialCollisions[newPosition] = new List<Vector>();
                }

                potentialCollisions[newPosition].Add(vector);                
            }

            if(hadCollision) {
                foreach(var list in collisions) {
                    vectors = vectors.Except(list).ToList();
                }
            }
            else {
                sinceLastCollision++;
            }

            ticksRun++;
        }

        return vectors.Count();
    }

    private static List<Vector> ParseInput(List<string> descriptions) {
        var vectors = new List<Vector>();
        var posRegex = new Regex(@"p=<(?<x>-?\d+),(?<y>-?\d+),(?<z>-?\d+)>");
        var velRegex = new Regex(@"v=<(?<x>-?\d+),(?<y>-?\d+),(?<z>-?\d+)>");
        var accRegex = new Regex(@"a=<(?<x>-?\d+),(?<y>-?\d+),(?<z>-?\d+)>");
        int i = 0;
        foreach(var line in descriptions) {
            var pos = posRegex.Matches(line);
            var vel = velRegex.Matches(line);
            var acc = accRegex.Matches(line);
            var positionPoints = GetVector(pos);
            var velocityPoints = GetVector(vel);
            var accelerationPoints = GetVector(acc);
            var acceleration = new Vector(-1, accelerationPoints, null, null);
            var velocity = new Vector(-1, velocityPoints, null, null);
            vectors.Add(new Vector(i, positionPoints, velocity, acceleration));
            i++;
        }

        return vectors;
    }

    private static (long x, long y, long z) GetVector(MatchCollection collection) {
        var x = long.Parse(collection[0].Groups["x"].Value);
        var y = long.Parse(collection[0].Groups["y"].Value);
        var z = long.Parse(collection[0].Groups["z"].Value);

        return (x: x, y: y, z: z);
    }
}