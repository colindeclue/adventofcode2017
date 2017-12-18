using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day18 {
    public static long Part1(string path) 
    {
        var instructions = File.ReadLines(path).ToList();
        var registers = new Dictionary<string, long>();
        long lastSoundPlayed = 0;
        int index = 0;
        while(true) {
            var instruction = instructions[index];
            var parts = instruction.Split();
            string toChange;
            long oldValue;
            long operand;
            switch(parts[0]) {
                case "snd":
                    lastSoundPlayed = CheckRegister(registers, parts[1]);
                    break;
                case "set":
                    operand = CheckRegister(registers, parts[2]);
                    registers[parts[1]] = operand;
                    break;
                case "add":
                    toChange = parts[1];
                    oldValue = CheckRegister(registers, toChange);
                    operand = CheckRegister(registers, parts[2]);
                    registers[toChange] = oldValue + operand;
                    break;
                case "mul":
                    toChange = parts[1];
                    oldValue = CheckRegister(registers, toChange);
                    operand = CheckRegister(registers, parts[2]);
                    registers[toChange] = oldValue * operand;
                    break;
                case "mod":
                    toChange = parts[1];
                    oldValue = CheckRegister(registers, toChange);
                    operand = CheckRegister(registers, parts[2]);
                    registers[toChange] = oldValue % operand;
                    break;
                case "rcv":
                    if(CheckRegister(registers, parts[1]) > 0) {
                        return lastSoundPlayed;
                    }
                    break;
                case "jgz":
                    toChange = parts[1];
                    oldValue = CheckRegister(registers, toChange);
                    operand = CheckRegister(registers, parts[2]);
                    if(oldValue > 0) {
                        index += (int)operand;
                        continue;
                    }
                    break;
            }
            index++;
        }
    }

    public static long Part2(string path) {
        var instructions = File.ReadLines(path).ToList();
        var aRunner = new InstructionRunner(instructions, 0);
        var bRunner = new InstructionRunner(instructions, 1);
        var fromA = new Queue<long>();
        var fromB = new Queue<long>();
        while(true) {
            fromA = aRunner.RunToStop(fromB);
            fromB = bRunner.RunToStop(fromA);
            if(fromA.Count == 0 && fromB.Count == 0) {
                return bRunner.SendCount;
            }
        }
    }

    public static long CheckRegister(Dictionary<string, long> register, string name) {
        long value;
        if(long.TryParse(name, out value)) {
            return value;
        }

        if(!register.ContainsKey(name)) {
            register[name] = 0;
        }

        return register[name];
    }
}