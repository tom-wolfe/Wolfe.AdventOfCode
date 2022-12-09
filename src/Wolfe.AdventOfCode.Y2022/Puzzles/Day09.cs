namespace Wolfe.AdventOfCode.Y2022.Puzzles;

using System.Drawing;

internal class Day09 : IPuzzleDay
{
    public int Day => 9;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default)
    {
        (int X, int Y) head = (0, 0);
        (int X, int Y) tail = (0, 0);

        var instructions = Parse(input);

        var tailPlaces = new List<(int, int)>();

        foreach (var (direction, distance) in instructions)
        {
            for (var d = 0; d < distance; d++)
            {
                head = MoveHead(direction, head);
                tail = MoveTail(head, tail);
                tailPlaces.Add((tail.X, tail.Y));
            }
        }

        return tailPlaces
            .Distinct()
            .Count()
            .ToString()
            .ToTask();
    }

    public Task<string> Part2(string input, CancellationToken cancellationToken = default) => ""
            .ToTask();

    private static IEnumerable<(char Direction, int Distance)> Parse(string input) => input
        .ToLines()
        .Select(r => r.Split(' '))
        .Select(t => (t[0][0], int.Parse(t[1], CultureInfo.InvariantCulture)));

    private static (int X, int Y) MoveHead(char direction, (int X, int Y) head) =>
        direction switch
        {
            'U' => (head.X, head.Y + 1),
            'D' => (head.X, head.Y - 1),
            'L' => (head.X - 1, head.Y),
            'R' => (head.X + 1, head.Y),
            _ => throw new InvalidOperationException("Invalid direction")
        };

    private static (int X, int Y) MoveTail((int X, int Y) head, (int X, int Y) tail)
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
