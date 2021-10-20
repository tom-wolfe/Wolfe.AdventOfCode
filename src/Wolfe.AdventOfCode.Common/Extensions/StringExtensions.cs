﻿namespace Wolfe.AdventOfCode.Common.Extensions
{
    public static class StringExtensions
    {
        public static int ToBinary(this string input, char one, char zero)
        {
            var binString = input.Replace(one, '1').Replace(zero, '0');
            return Convert.ToInt32(binString, 2);
        }

        public static List<List<string>> GroupLines(this string input)
        {
            return GroupLines(input.Split(Environment.NewLine));
        }

        public static List<List<string>> GroupLines(this IEnumerable<string> lines)
        {
            var result = new List<List<string>>();
            var group = new List<string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    result.Add(group);
                    group = new List<string>();
                }
                else
                    group.Add(line);
            }
            if (group.Any()) { result.Add(group); }
            return result;
        }
    }
}