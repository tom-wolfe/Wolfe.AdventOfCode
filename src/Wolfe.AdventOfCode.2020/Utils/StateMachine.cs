using System.Runtime.InteropServices;

namespace Wolfe.AdventOfCode._2020.Utils
{
    internal class StateMachine
    {
        private const string NOP = "nop";
        private const string JMP = "jmp";
        private const string ACC = "acc";

        private record Instruction(string Operation, int Value);

        private readonly List<Instruction> _instructions;


        public StateMachine(IEnumerable<string> instructions)
        {
            _instructions = instructions.Select(ParseInstruction).ToList();
        }

        public int RunUntilLoop()
        {
            return RunUntilLoop(_instructions).Item1;
        }

        public int RunWithAutoFix()
        {
            var nopOrJmp = new Stack<int>();
            for (var x = 0; x < _instructions.Count; x++)
            {
                if (_instructions[x].Operation is NOP or JMP)
                    nopOrJmp.Push(x);
            }

            while (true)
            {
                var instructions = _instructions.Select(SwapInstruction(nopOrJmp.Pop())).ToList();
                var (result, ranToEnd) = RunUntilLoop(instructions);
                if (ranToEnd) { return result; }
            }
        }

        private static Func<Instruction, int, Instruction> SwapInstruction(int index) => (instruction, i) => i == index
            ? instruction with { Operation = instruction.Operation == NOP ? JMP : NOP }
            : instruction;

        private static (int, bool) RunUntilLoop(IReadOnlyList<Instruction> instructions)
        {
            var accumulator = 0;
            var curIndex = 0;
            var history = new List<int>();

            while (true)
            {
                if (history.Contains(curIndex)) { return (accumulator, false); }
                if (curIndex >= instructions.Count) { return (accumulator, true); }
                history.Add(curIndex);

                var (operation, value) = instructions[curIndex];
                switch (operation)
                {
                    case NOP: break;
                    case ACC: accumulator += value; break;
                    case JMP: curIndex += value; continue;
                }
                curIndex++;
            }
        }

        private static Instruction ParseInstruction(string instruction)
        {
            var parts = instruction.Split(' ');
            return new Instruction(parts[0], int.Parse(parts[1]));
        }
    }
}
