using System;
using System.Collections.Generic;
using System.Linq;

public static class Day17 {
    public static int Part1(int stepSize, int steps) {
        var list = new LinkedList<int>();
        var current = list.AddFirst(0);
        for(int i = 1; i <= steps; i++) {
            var length = list.Count;
            var previous = current;
            for(int j = 0; j < stepSize; j++) {
                previous = previous.Next;
                if(previous == null) {
                    previous = list.First;
                }
            }
            current = list.AddAfter(previous, i);
        }

        return current.Next.Value;
    }

    // public static int Part2(int stepSize, int steps) {
    //     var list = new LinkedList<int>();
    //     var current = list.AddFirst(0);
    //     for(int i = 1; i <= steps; i++) {
    //         var length = list.Count;
    //         var previous = current;
    //         for(int j = 0; j < stepSize; j++) {
    //             previous = previous.Next;
    //             if(previous == null) {
    //                 previous = list.First;
    //             }
    //         }
    //         current = list.AddAfter(previous, i);
    //         if(i % 1000000 == 0) {
    //             Console.WriteLine(i);
    //         }
    //     }

    //     return list.First.Next.Value;
    // }

    public static int Part2(int stepSize, int steps) {
        var list = new List<int>() { 0 };
        var index = 0;
        var current = -1;
        var length = 1;
        for(int i = 1; i <= steps; i++) {
            index = ((index + stepSize + 1) % length);
            if(index == 0) {
                current = i;
            }
            length++;
        }
        Console.WriteLine(length);
        return current;
    }
}