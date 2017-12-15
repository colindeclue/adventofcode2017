using System;
using System.Collections.Generic;
using System.Linq;

public static class Day10 {
    public static int Part1(int listSize, string input) {
        var lengths = input.Split(',').Select(s => int.Parse(s)).ToArray();

        var runner = new KnotRunner(listSize, lengths);
        runner.DoRound();

        return runner.List[0] * runner.List[1];
    }

    public static string Part2(int listSize, string input) {
        var standardAddition = new int[] {17, 31, 73, 47, 23};
        var lengths = input.Select(c => (int)Convert.ToByte(c)).Concat(standardAddition).ToArray();
        var runner = new KnotRunner(listSize, lengths);
        var denseHash = runner.GetResult();

        var hexString = BitConverter.ToString(denseHash.ToArray());

        return hexString.Replace("-", string.Empty);
    }
}