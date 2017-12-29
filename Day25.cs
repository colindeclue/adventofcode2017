using System.Collections.Generic;
using System.Linq;

public static class Day25 {
    public static int Part1(int steps) {
        var state = 'A';
        var tape = new Dictionary<long, int>();
        long cursor = 0;
        for(int i = 0; i < steps; i++) {
            switch(state) {
                case 'A':
                    if(CheckTape(tape, cursor) == 0) {
                        tape[cursor] = 1;
                        cursor++;
                        state = 'B';
                    }
                    else {
                        tape[cursor] = 0;
                        cursor--;
                        state = 'E';
                    }
                    break;
                case 'B':
                    if(CheckTape(tape, cursor) == 0) {
                        tape[cursor] = 1;
                        cursor--;
                        state = 'C';
                    }
                    else {
                        tape[cursor] = 0;
                        cursor++;
                        state = 'A';
                    }
                    break;
                case 'C':
                    if(CheckTape(tape, cursor) == 0) {
                        tape[cursor] = 1;
                        cursor--;
                        state = 'D';
                    }
                    else {
                        tape[cursor] = 0;
                        cursor++;
                        state = 'C';
                    }
                    break;
                case 'D':
                    if(CheckTape(tape, cursor) == 0) {
                        tape[cursor] = 1;
                        cursor--;
                        state = 'E';
                    }
                    else {
                        tape[cursor] = 0;
                        cursor--;
                        state = 'F';
                    }
                    break;
                case 'E':
                    if(CheckTape(tape, cursor) == 0) {
                        tape[cursor] = 1;
                        cursor--;
                        state = 'A';
                    }
                    else {
                        tape[cursor] = 1;
                        cursor--;
                        state = 'C';
                    }
                    break;
                case 'F':
                    if(CheckTape(tape, cursor) == 0) {
                        tape[cursor] = 1;
                        cursor--;
                        state = 'E';
                    }
                    else {
                        tape[cursor] = 1;
                        cursor++;
                        state = 'A';
                    }
                    break;
            }
        }

        return tape.Values.Sum();
    }

    private static int CheckTape(Dictionary<long, int> tape, long toCheck) {
        if(!tape.ContainsKey(toCheck)) {
            tape[toCheck] = 0;
        }

        return tape[toCheck];
    }
}