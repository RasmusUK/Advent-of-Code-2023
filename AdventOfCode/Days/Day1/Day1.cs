using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days.Day1;

public class Day1 : Day
{
    public Day1(int day) : base(day)
    {
    }

    protected override object Part1(List<string> input)
    {
        return input.Sum(line =>
        {
            var numbers = line.Where(char.IsNumber);
            return int.Parse(new string(new [] { numbers.First(), numbers.Last() }));
        });
    }

    protected override object Part2(List<string> input)
    {
        return input.Sum(line => SumLine(line));
    }

    private int SumLine(string line)
    {
        var first = '0';
        var last = '0';

        for (var i = 0; i < line.Length && first == '0'; i++)
        {
            first = GetFirstMatch(line.Substring(i));
        }
        
        for (var i = line.Length-1; i >= 0 && last == '0'; i--)
        {
            last = GetFirstMatch(line.Substring(i));
        }

        return int.Parse(new string(new [] { first, last }));
    }

    private char GetFirstMatch(string line)
    {
        var numberMapping = new Dictionary<string, char>
        {
            {"one", '1'},
            {"two", '2'},
            {"three", '3'},
            {"four", '4'},
            {"five", '5'},
            {"six", '6'},
            {"seven", '7'},
            {"eight", '8'},
            {"nine", '9'}
        };
        
        foreach (var number in numberMapping.Keys)
        {
            if(line.StartsWith(number)) return numberMapping[number];
            if (char.IsNumber(line[0])) return line[0];
        }

        return '0';
    }
}