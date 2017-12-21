using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Day21 {
    public static int Part1(string path, int iterations) {
        var start = new char[3,3]{{'.','#','.'},{'.','.','#'},{'#','#','#'}};
        var input = File.ReadLines(path).ToList();
        var rules = ParseInput(input);
        for(int i = 0; i < iterations; i++) {
            var squares = Split(start);
            var endSquares = new List<char[,]>();
            foreach(var square in squares) {
                endSquares.Add(Grow(rules, square));
            }
            start = Combine(endSquares);
            Console.WriteLine(i);
        }

        return start.Cast<char>().Count(c => c == '#');
    }

    private static List<char[,]> Split(char[,] input) {
        var n = (int)Math.Sqrt(input.Length);
        var output = new List<char[,]>();
        int squareSize;
        if(n % 2 == 0) {
            // 2 by 2 squares
            squareSize = 2;
        }
        else {
            // 3 by 3 squares
            squareSize = 3;            
        }

        var totalSquares = (n / squareSize) * (n / squareSize);
        for(int i = 0; i < totalSquares; i++) {
            output.Add(new char[squareSize,squareSize]);
        }
        for(int y = 0; y < n; y++) {
            for(int x = 0; x < n; x++) {
                var yOffset = (y / squareSize) * (n / squareSize);
                var xOffset = x / squareSize;
                var pieceIndex = yOffset + xOffset;
                var matrixTo = output[pieceIndex];
                matrixTo[y % squareSize, x % squareSize] = input[y, x];
            }
        }

        return output;
    }

    private static char[,] Grow(Dictionary<string, string> rules, char[,] input) {
        var n = (int)Math.Sqrt(input.Length);
        var key = GetKey(input, n);
        if(rules.ContainsKey(key)) {
            return FromKey(rules[key]);
        }
        var flipped = Flip(input, n);
        key = GetKey(flipped, n);

        if(rules.ContainsKey(key)) {
            return FromKey(rules[key]);
        }

        var rotations = Rotations(input, n);
        foreach(var rotation in rotations) {
            key = GetKey(rotation, n);
            if(rules.ContainsKey(key)) {
                return FromKey(rules[key]);
            }
        }

        rotations = Rotations(flipped, n);
        foreach(var rotation in rotations) {
            key = GetKey(rotation, n);
            if(rules.ContainsKey(key)) {
                return FromKey(rules[key]);
            }
        }

        Console.WriteLine($"Uh oh! Couldn't find one that worked for {GetKey(input, n)}");
        return input;
    }

    private static Dictionary<string, string> ParseInput(List<string> input) {
        var rules = input.Select(s => s.Split(new [] {"=>"}, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList());
        var dict = new Dictionary<string, string>();
        foreach(var rule in rules) {
            dict[rule[0]] = rule[1];
        }

        return dict;
    }

    private static void Print(char[,] matrix) {
        var n = (int)Math.Sqrt(matrix.Length);
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n; j++) {
                Console.Write(matrix[i, j]);
            }
            Console.Write("\n");
        }
    }

    private static List<char[,]> Rotations(char[,] inputSquare, int n) {
        var retList = new List<char[,]>();
        var current = inputSquare;
        for(int i = 0; i < 3; i++) {
            current = RotateOnce(current, n);
            retList.Add(current);
        }

        return retList;
    }

    private static char[,] Combine(List<char[,]> pieces) {
        var squareSize = (int)Math.Sqrt(pieces.First().Length);
        var numSquares = pieces.Count();
        var n = squareSize * (int)Math.Sqrt(numSquares);
        char[,] ret = new char[n, n];
		var squaresPerRow = (n / squareSize);

        for(int y = 0; y < n; y++) {
            for(int x = 0; x < n; x++) {
                var yOffset = (y / squareSize) * squaresPerRow;
                var xOffset = x / squareSize;
                var pieceIndex = yOffset + xOffset;
                var matrixFrom = pieces[pieceIndex];
                ret[y, x] = matrixFrom[y % squareSize, x % squareSize];
            }
        }

		return ret;
    }

    private static char[,] Flip(char[,] matrix, int n) {
        char[,] ret = new char[n, n];
        for(int y = 0; y < n; y++) {
            for(int x = 0; x < n; x++) {
                if(x == 0) {
                    ret[x, y] = matrix[n - 1, y];
                }
                else if(x == n -1) {
                    ret[x, y] = matrix[0, y];
                }
                else {
                    ret[x, y] = matrix[x, y];
                }
            }
        }

        return ret;
    }

    private static char[,] RotateOnce(char[,] matrix, int n) {
        char[,] ret = new char[n, n];

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                ret[i, j] = matrix[n - j - 1, i];
            }
        }

        return ret;
    }

    private static string GetKey(char[,] square, int n = -1) {
        if(n == -1) {
            n = (int)Math.Sqrt(square.Length);
        }
        var stringBuilder = new StringBuilder();
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n; j++) {
                stringBuilder.Append(square[i,j]);
            }
            stringBuilder.Append('/');
        }

        return stringBuilder.ToString().TrimEnd('/');
    }

    private static char[,] FromKey(string key) {
        var rows = key.Split(new []{'/'}, StringSplitOptions.RemoveEmptyEntries);
        var n = rows.Count();
        var ret = new char[n,n];
        for(int i = 0; i < n; i++) {
            for(int j = 0; j < n; j++) {
                ret[i,j] = rows[i][j];
            }
        }

        return ret;
    }
}