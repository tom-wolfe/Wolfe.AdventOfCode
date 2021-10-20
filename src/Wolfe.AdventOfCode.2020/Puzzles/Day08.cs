using Wolfe.AdventOfCode._2020.Utils;
using Wolfe.AdventOfCode.Common;

namespace Wolfe.AdventOfCode._2020.Puzzles
{
    internal class Day08 : IPuzzleDay
    {
        public int Day { get; } = 8;

        private readonly StateMachine _stateMachine;
        public Day08()
        {
            var lines = File.ReadAllLines("./Inputs/Day08.txt");
            _stateMachine = new StateMachine(lines);
        }

        public Task<string> Part1(CancellationToken cancellationToken = default)
        {
            var result = _stateMachine.RunUntilLoop();
            return Task.FromResult(result.ToString());
        }

        public Task<string> Part2(CancellationToken cancellationToken = default)
        {
            var result = _stateMachine.RunWithAutoFix();
            return Task.FromResult(result.ToString());
        }
    }
}
