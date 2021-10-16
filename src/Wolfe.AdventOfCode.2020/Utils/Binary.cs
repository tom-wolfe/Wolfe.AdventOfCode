namespace Wolfe.AdventOfCode._2020.Utils
{
    public static class Binary
    {
        public static int FromString(string input, char one, char zero)
        {
            var binString = input.Replace(one, '1').Replace(zero, '0');
            return Convert.ToInt32(binString, 2);
        }
    }
}
