using System.Collections.Generic;

public static class Day06 {
    public static int Part1(int[] memory) {
        var knownStates = new HashSet<string>();
        var count = 0;
        while(true) {
            if(knownStates.Contains(string.Join(",", memory))){
                return count;
            }
            knownStates.Add(string.Join(",", memory));
            memory = GetNewState(memory);
            count++;
        }
    }

    public static int Part2(int[] memory) {
        var knownStates = new HashSet<string>();
        var allStates = new List<string>();
        var count = 0;
        while(true) {
            if(knownStates.Contains(string.Join(",", memory))){
                var firstFound = allStates.IndexOf(string.Join(",", memory));
                return count - firstFound;
            }

            knownStates.Add(string.Join(",", memory));
            allStates.Add(string.Join(",", memory));
            memory = GetNewState(memory);
            count++;
        }
    }

    private static int[] GetNewState(int[] memory) {
        var biggestIndex = -1;
        var biggest = -1;
        for(int i = 0; i < memory.Length; i++) {
            if(memory[i] > biggest) {
                biggest = memory[i];
                biggestIndex = i;
            }
        }

        memory[biggestIndex] = 0;
        for(int i = biggestIndex + 1; biggest > 0; biggest--, i++) {
            memory[i % memory.Length]++;
        }

        return memory;
    }
}