using System;

public static class Day15 {
    public static int Part1(long genA, long genB, int runs) {
        var matches = 0;
        long aFactor = 16807;
        long bFactor = 48271;
        for(var i = 0; i < runs; i++) {
            genA = (genA * aFactor) % 2147483647;
            genB = (genB * bFactor) % 2147483647;
            if((genA & 65535) == (genB & 65535)) {
                matches++;
            }
        }

        return matches;
    }

    public static int Part2(long genA, long genB, int runs) {
        var matches = 0;
        long aFactor = 16807;
        long bFactor = 48271;
        for(var i = 0; i < runs; i++) {
            genA = (genA * aFactor) % 2147483647;
            while((genA % 4) != 0) {
                genA = (genA * aFactor) % 2147483647;
            }
            genB = (genB * bFactor) % 2147483647;
            while((genB % 8) != 0) {
                genB = (genB * bFactor) % 2147483647;
            }
            if((genA & 65535) == (genB & 65535)) {
                matches++;
            }
        }

        return matches;
    }
}