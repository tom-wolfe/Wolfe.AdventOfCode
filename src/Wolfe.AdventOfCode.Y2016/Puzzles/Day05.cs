using System.Security.Cryptography;
using System.Text;

namespace Wolfe.AdventOfCode.Y2016.Puzzles;

internal class Day05 : IPuzzleDay
{
    public int Day => 5;

    public Task<string> Part1(string input, CancellationToken cancellationToken = default) =>
        PasswordGenerator(input)
        .Take(8)
        .Select(t => t.Item2)
        .Join()
        .ToTask();

    public Task<string> Part2(string input, CancellationToken cancellationToken = default)
    {
        var password = Enumerable.Repeat('_', 8).ToArray();

        var generator = PasswordGenerator(input);
        using var enumerator = generator.GetEnumerator();
        while (password.Contains('_'))
        {
            enumerator.MoveNext();
            var nextChar = enumerator.Current;

            if (nextChar.Item1 < password.Length && password[nextChar.Item1] == '_')
            {
                password[nextChar.Item1] = nextChar.Item2;
            }
        }

        return password.Join().ToTask();
    }

    private static IEnumerable<(int, char)> PasswordGenerator(string doorId)
    {
        var md5 = MD5.Create();
        var salt = 0;

        while (salt < int.MaxValue)
        {
            var password = doorId + salt;
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = md5.ComputeHash(bytes);
            var output = Convert.ToHexString(hash);
            if (output.StartsWith("00000"))
            {
                var index = Convert.ToInt32(output[5].ToString(), 16);
                yield return (index, output[6]);
            }
            salt++;
        }
    }
}
