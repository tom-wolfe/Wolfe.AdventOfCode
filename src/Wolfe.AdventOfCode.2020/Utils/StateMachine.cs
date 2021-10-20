namespace Wolfe.AdventOfCode._2020.Utils
{
    internal class StateMachine
    {
        private record Instruction(string Operation, int Value);

        private readonly List<Instruction> _instructions;


        public StateMachine(IEnumerable<string> instructions)
        {
            _instructions = instructions.Select(ParseInstruction).ToList();
        }

        public int RunUntilLoop()
        {
            var accumulator = 0;
            var curIndex = 0;
            var history = new List<int>();

            while (true)
            {
                if (history.Contains(curIndex)) { return accumulator; }
                history.Add(curIndex);
                var current = _instructions[curIndex];
                switch (current.Operation)
                {
                    case "nop": break;
                    case "acc": accumulator += current.Value; break;
                    case "jmp": curIndex += current.Value; continue;
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
