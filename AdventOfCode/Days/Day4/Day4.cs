using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days.Day4;

public class Day4 : Day
{
    public Day4(int day) : base(day)
    {
    }

    protected override object Part1(List<string> input)
    { 
        return GetWinningNumbers(input).Sum(line => double.Floor(double.Pow(2, line.Count()-1)));
    }

    protected override object Part2(List<string> input)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < input.Count; i++)
        {
            dict[i + 1] = 1;
        }
        
        var lines = GetWinningNumbers(input).ToList();
        for (var i = 0; i < lines.Count; i++)
        {
            for (var j = 0; j < lines[i].Count(); j++)
            {
                dict[i + j + 2] += dict[i + 1];
            }
        }
        
        return dict.Sum(kv => kv.Value);
    }

    private static IEnumerable<IEnumerable<int>> GetWinningNumbers(List<string> input)
    {
        var split = input.Select(line => line.Split(":")[1])
            .Select(line => line.Split("|"));
        var lines = split.Select(line => (
            line[0].Replace("  "," ").Trim().Split(" ").Select(n => int.Parse(n)), 
            line[1].Replace("  "," ").Trim().Split(" ").Select(n => int.Parse(n))));
        return lines.Select(line => line.Item2.Where(nr => line.Item1.Contains(nr)));
    }
}