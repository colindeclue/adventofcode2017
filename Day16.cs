using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day16 {
    public static string Part1(string path, string dancers, int times = 1) {
        var moves = File.ReadAllLines(path).First().Split(',').ToList();
        var moveResults = new Dictionary<string, string>();
        var danceResults = new Dictionary<string, string>();
        var loopFound = false;
        for(int i = 0; i < times; i++) {
            var dancersKey = dancers;
            if(loopFound) {
                dancers = danceResults[dancersKey];
                continue;
            }
            if(danceResults.ContainsKey(dancersKey)) {
                dancers = danceResults[dancersKey];
                loopFound = true;
                continue;
            }
            foreach(var move in moves) {
                var key = dancers + move;
                if(moveResults.ContainsKey(key)) {
                    dancers = moveResults[key];
                    continue;
                }
                var danceMove = move[0];
                var parts = move.Substring(1);
                switch(move[0]) {
                    case 's':
                        var count = int.Parse(parts);
                        dancers = Spin(dancers, count);
                        break;
                    case 'x':
                        var exchanges = parts.Split('/');
                        var first = int.Parse(exchanges[0]);
                        var second = int.Parse(exchanges[1]);
                        dancers = Exchange(dancers, first, second);
                        break;
                    case 'p':
                        var partners = parts.Split('/');
                        var firstLetter = partners[0][0];
                        var secondLetter = partners[1][0];
                        dancers = Partner(dancers, firstLetter, secondLetter);
                        break;
                }
                moveResults[key] = dancers;
            }
            danceResults[dancersKey] = dancers;
        }

        return dancers;
    }

    public static string Part2(string path, string dancers, int times) {
        return Part1(path, dancers, times);
    }

    private static string Spin(string dancers, int count) {
        var end = dancers.Substring(dancers.Length - count);
        return end + dancers.Substring(0, dancers.Length - count);
    }

    private static string Exchange(string dancers, int first, int second) {
        var a = dancers[first];
        var b = dancers[second];
        var asArray = dancers.ToCharArray();
        asArray[first] = b;
        asArray[second] = a;

        return new string(asArray);
    }

    private static string Partner(string dancers, char first, char second) {
        var firstIndex = dancers.IndexOf(first);
        var secondIndex = dancers.IndexOf(second);

        return Exchange(dancers, firstIndex, secondIndex);
    }
}