using System.Collections.Generic;

public class InstructionRunner {
    public int Id {get; set;}

    private List<string> _instructions;

    private Dictionary<string, long> _registers;

    private int _index = 0;

    public int SendCount = 0;

    public InstructionRunner(List<string> instructions, int id) {
        this.Id = id;
        this._registers = new Dictionary<string, long>();
        this._instructions = instructions;
        this._registers["p"] = id;
    }

    public Queue<long> RunToStop(Queue<long> input) {
        var toSend = new Queue<long>();
        while(true) {
            if(this._index >= this._instructions.Count) {
                return toSend;
            }

            var instruction = this._instructions[this._index];
            var parts = instruction.Split();
            string toChange;
            long oldValue;
            long operand;
            switch(parts[0]) {
                case "snd":
                    this.SendCount++;
                    toSend.Enqueue(Day18.CheckRegister(this._registers, parts[1]));
                    break;
                case "set":
                    operand = Day18.CheckRegister(this._registers, parts[2]);
                    this._registers[parts[1]] = operand;
                    break;
                case "add":
                    toChange = parts[1];
                    oldValue = Day18.CheckRegister(this._registers, toChange);
                    operand = Day18.CheckRegister(this._registers, parts[2]);
                    this._registers[toChange] = oldValue + operand;
                    break;
                case "mul":
                    toChange = parts[1];
                    oldValue = Day18.CheckRegister(this._registers, toChange);
                    operand = Day18.CheckRegister(this._registers, parts[2]);
                    this._registers[toChange] = oldValue * operand;
                    break;
                case "mod":
                    toChange = parts[1];
                    oldValue = Day18.CheckRegister(this._registers, toChange);
                    operand = Day18.CheckRegister(this._registers, parts[2]);
                    this._registers[toChange] = oldValue % operand;
                    break;
                case "rcv":
                    if(input.Count > 0) {
                        operand = input.Dequeue();
                        toChange = parts[1];
                        this._registers[toChange] = operand;
                    }
                    else {
                        return toSend;
                    }
                    break;
                case "jgz":
                    toChange = parts[1];
                    oldValue = Day18.CheckRegister(this._registers, toChange);
                    operand = Day18.CheckRegister(this._registers, parts[2]);
                    if(oldValue > 0) {
                        this._index += (int)operand;
                        continue;
                    }
                    break;
            }
            this._index++;
        }
    }
}