using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Day08 {
    public static (int globalMax, int endMax) DoAll(string path) {
        var lines = File.ReadLines(path);
        var registers = new Dictionary<string, int>();
        var globalMax = int.MinValue;
        foreach(var line in lines) {
            //b inc 5 if a > 1
            var parts = line.Split();
            var toChange = parts[0];
            var sign = parts[1] == "inc" ? 1 : -1;
            var amount = int.Parse(parts[2]);
            var checkRegister = parts[4];
            var operation = parts[5];
            var compareTo = int.Parse(parts[6]);
            var registerValue = CheckRegister(registers, checkRegister);
            if(registerValue > globalMax) {
                globalMax = registerValue;
            }
            if(Operations[operation](registerValue, compareTo)) {
                registers[toChange] = CheckRegister(registers, toChange) + (sign * amount);
                // var newValue = CheckRegister(registers, toChange) + (sign * amount);
                // if(newValue > globalMax) {
                //     globalMax = newValue;
                //     registers[toChange] = newValue;
                // }
            }
        }

        return (globalMax: globalMax, endMax: registers.Values.Max());
    }

    private static Dictionary<string, Func<int, int, bool>> Operations = new Dictionary<string, Func<int, int, bool>>
    {
        {">", (registerValue, compareTo) => registerValue > compareTo},
        {"<", (registerValue, compareTo) => registerValue < compareTo},
        {"==", (registerValue, compareTo) => registerValue == compareTo},
        {">=", (registerValue, compareTo) => registerValue >= compareTo},
        {"<=", (registerValue, compareTo) => registerValue <= compareTo},
        {"!=", (registerValue, compareTo) => registerValue != compareTo}
    };

    private static int CheckRegister(Dictionary<string, int> register, string name) {
        if(!register.ContainsKey(name)) {
            register[name] = 0;
        }

        return register[name];
    }
}