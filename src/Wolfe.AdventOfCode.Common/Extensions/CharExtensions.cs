namespace Wolfe.AdventOfCode.Extensions;

public static class CharExtensions
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static char CaesarShift(this char input, int distance)
    {
        var lChar = char.ToLower(input);
        var cIndex = Alphabet.IndexOf(lChar);

        if (cIndex == -1)
        { return input; }
        cIndex = (cIndex + distance) % Alphabet.Length;

        return input == lChar ? Alphabet[cIndex] : char.ToUpper(Alphabet[cIndex]);
    }
}
