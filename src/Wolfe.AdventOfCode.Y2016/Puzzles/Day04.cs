namespace Wolfe.AdventOfCode.Y2016.Puzzles;

internal class Day04 : IPuzzleDay
{
    private static readonly Regex RoomRegex = new(@"(?<name>.+)-(?<sector>\d+)\[(?<checksum>.+)\]");

    public int Day => 4;

    public Task<string> Part1(string? input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(ParseRoom)
        .Where(r => r.IsReal())
        .Select(r => r.SectorId)
        .Sum()
        .ToString()
        .ToTask();

    public Task<string> Part2(string? input, CancellationToken cancellationToken = default) => input
        .ToLines()
        .Select(ParseRoom)
        .First(r => r.Decrypt() == "northpole object storage")
        .SectorId
        .ToString()
        .ToTask();

    private static Room ParseRoom(string input)
    {
        var result = RoomRegex.Match(input);
        return new Room(result.Groups["name"].Value, int.Parse(result.Groups["sector"].Value), result.Groups["checksum"].Value);
    }

    private record Room(string Name, int SectorId, string Checksum)
    {
        public string Decrypt() => Name.CaesarShift(SectorId).Replace('-', ' ');

        public bool IsReal() => Checksum == Name
            .Replace("-", null)
            .CharacterFrequency()
            .OrderByDescending(f => f.Value)
            .ThenBy(f => f.Key)
            .Take(5)
            .Select(f => f.Key)
            .Join();
    }
}
