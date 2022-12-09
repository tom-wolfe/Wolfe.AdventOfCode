namespace Wolfe.AdventOfCode.Y2022.Puzzles;

internal class Day09 : IPuzzleDay
{
    public int Day => 9;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default)
    {
        var rope = MakeRope(2);
        var instructions = Parse(input);
        return MoveRope(rope, instructions)
            .Distinct()
            .Count()
            .ToString()
            .ToTask();
    }

    public Task<string> Part2(string input, CancellationToken cancellationToken = default)
    {
        var rope = MakeRope(10);
        var instructions = Parse(input);
        return MoveRope(rope, instructions)
            .Distinct()
            .Count()
            .ToString()
            .ToTask();
    }

    private static IEnumerable<(int X, int Y)> MakeRope(int knots) => Enumerable.Range(1, knots).Select(_ => (0, 0));

    private static IEnumerable<(char Direction, int Distance)> Parse(string input) => input
        .ToLines()
        .Select(r => r.Split(' '))
        .Select(t => (t[0][0], int.Parse(t[1], CultureInfo.InvariantCulture)));

    private static IEnumerable<(int X, int Y)> MoveRope(IEnumerable<(int X, int Y)> rope, IEnumerable<(char Direction, int Distance)> instructions)
    {
        var ropeList = rope.ToList();
        var knotPlaces = new List<(int X, int Y)>();
        foreach (var (direction, distance) in instructions)
        {
            for (var d = 0; d < distance; d++)
            {
                for (var i = 0; i < ropeList.Count; i++)
                {
                    if (i == 0)
                    {
                        // If it's the head, move in the given direction.
                        ropeList[i] = MoveHead(direction, ropeList[i]);
                    }
                    else
                    {
                        // If it's the tail, then move towards the piece in front.
                        ropeList[i] = MoveKnot(ropeList[i - 1], ropeList[i]);
                    }

                    // If it's the last piece of rope.
                    if (i == ropeList.Count - 1)
                    {
                        knotPlaces.Add((ropeList[i].X, ropeList[i].Y));
                    }
                }
            }
        }

        return knotPlaces;
    }

    private static (int X, int Y) MoveHead(char direction, (int X, int Y) head) =>
        direction switch
        {
            'U' => (head.X, head.Y + 1),
            'D' => (head.X, head.Y - 1),
            'L' => (head.X - 1, head.Y),
            'R' => (head.X + 1, head.Y),
            _ => throw new InvalidOperationException("Invalid direction")
        };

    private static (int X, int Y) MoveKnot((int X, int Y) head, (int X, int Y) tail)
    {
        var (x, y) = tail;

        var xDrag = Math.Abs(head.X - tail.X) > 1;
        var yDrag = Math.Abs(head.Y - tail.Y) > 1;

        if (head.X > tail.X + 1 || (head.X > tail.X && yDrag))
        {
            x++;
        }
        else if (head.X < tail.X - 1 || (head.X < tail.X && yDrag))
        {
            x--;
        }

        if (head.Y > tail.Y + 1 || (head.Y > tail.Y && xDrag))
        {
            y++;
        }
        else if (head.Y < tail.Y - 1 || (head.Y < tail.Y && xDrag))
        {
            y--;
        }

        return (x, y);
    }
}
