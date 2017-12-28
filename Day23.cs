using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day23 {

    public static int Part1(string path) {
        var instructions = File.ReadLines(path).ToList();
        var registers = new Dictionary<string, long>();
        var mulCount = 0;
        int index = 0;
        while(true) {
            if(index >= instructions.Count || index < 0) {
                break;
            }
            var instruction = instructions[index];
            var parts = instruction.Split();
            string toChange;
            long oldValue;
            long operand;
            switch(parts[0]) {
                // case "snd":
                //     lastSoundPlayed = CheckRegister(registers, parts[1]);
                //     break;
                case "set":
                    operand = CheckRegister(registers, parts[2]);
                    registers[parts[1]] = operand;
                    break;
                case "sub":
                    toChange = parts[1];
                    oldValue = CheckRegister(registers, toChange);
                    operand = CheckRegister(registers, parts[2]);
                    registers[toChange] = oldValue - operand;
                    break;
                // case "add":
                //     toChange = parts[1];
                //     oldValue = CheckRegister(registers, toChange);
                //     operand = CheckRegister(registers, parts[2]);
                //     registers[toChange] = oldValue + operand;
                //     break;
                case "mul":
                    toChange = parts[1];
                    oldValue = CheckRegister(registers, toChange);
                    operand = CheckRegister(registers, parts[2]);
                    registers[toChange] = oldValue * operand;
                    mulCount++;
                    break;
                // case "mod":
                //     toChange = parts[1];
                //     oldValue = CheckRegister(registers, toChange);
                //     operand = CheckRegister(registers, parts[2]);
                //     registers[toChange] = oldValue % operand;
                //     break;
                // case "rcv":
                //     if(CheckRegister(registers, parts[1]) > 0) {
                //         return lastSoundPlayed;
                //     }
                //     break;
                // case "jgz":
                //     toChange = parts[1];
                //     oldValue = CheckRegister(registers, toChange);
                //     operand = CheckRegister(registers, parts[2]);
                //     if(oldValue > 0) {
                //         index += (int)operand;
                //         continue;
                //     }
                //     break;
                case "jnz":
                    toChange = parts[1];
                    oldValue = CheckRegister(registers, toChange);
                    operand = CheckRegister(registers, parts[2]);
                    if(oldValue != 0) {
                        index += (int)operand;
                        continue;
                    }
                    break;
            }
            index++;
        }

        return mulCount;
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

    public static int Part2() {
        var count = 0;
        for(int i = 108100; i <= 125100; i+=17) {
            if(!IsPrime(i)) {
                count++;
            }
        }

        return count;
    }

    public static bool IsPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0)  return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i+=2)
        {
            if (number % i == 0)  return false;
        }

        return true;        
    }
}