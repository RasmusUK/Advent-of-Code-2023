using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days.Day3;

public class Day3 : Day
{
    public Day3(int day) : base(day)
    {
    }

    protected override object Part1(List<string> input)
    {
        var sum = 0;

        for (var i = 0; i < input.Count; i++)
        {
            var start = -1;

            for (var j = 0; j < input.First().Length; j++)
            {
                if (start == -1 && char.IsNumber(input[i][j]))
                {
                    start = j;
                }
                else if (start != -1 && !char.IsNumber(input[i][j]))
                {
                    if (IsAdjacent(input, GetPositionsFromPosition(i, start, j - 1)))
                    {
                        sum += int.Parse(input[i].Substring(start, j - start));
                    }

                    start = -1;
                }
            }
        }
        
        return sum;
    }

    protected override object Part2(List<string> input)
    {
        var dictionary = new Dictionary<(int, int), HashSet<int>>();
        
        for (var i = 0; i < input.Count; i++)
        {
            var start = -1;

            for (var j = 0; j < input.First().Length; j++)
            {
                if (start == -1 && char.IsNumber(input[i][j]))
                {
                    start = j;
                }
                else if (start != -1 && !char.IsNumber(input[i][j]))
                {
                    var number = int.Parse(input[i].Substring(start, j - start));
                    
                    foreach (var pos in GetAdjacentStarList(input, GetPositionsFromPosition(i, start, j - 1)))
                    {
                        if (!dictionary.ContainsKey(pos)) dictionary[pos] = new HashSet<int>();
                        dictionary[pos].Add(number);
                    }

                    start = -1;
                }
            }
        }

        var sum = 0;
        
        foreach (var numbers in dictionary.Values)
        {
            var numberList = numbers.ToList();
            Console.WriteLine("---");
            foreach (var x in numberList)
            {
                Console.WriteLine(x);
            }
            if (numbers.Count == 2)
            {
                Console.WriteLine($"{numberList[0]} {numberList[1]}");
                sum += numberList[0] * numberList[1];
            }
        }
        
        return sum;
    }

    private static List<(int i, int j)> GetPositionsFromPosition(int i, int start, int end)
    {
        var list = new List<(int, int)>();
        
        for (var j = start; j <= end; j++)
        {
            list.Add((i, j));
        }

        return list;
    }

    private static List<(int i, int j)> GetAdjacentStarList(List<string> input,
        List<(int i, int j)> positions)
    {
        return GetPositions(positions).Where(pos => IsInsideMap(input, pos) && input[pos.i][pos.j] == '*').ToList();
    }

    private static bool IsAdjacent(List<string> input, List<(int i, int j)> positions)
    {
        return GetPositions(positions).Any(pos => IsInsideMap(input, pos) && IsSymbol(input[pos.i][pos.j]));
    }

    private static bool IsInsideMap(List<string> input, (int i, int j) pos)
    {
        return pos.i >= 0 && pos.i < input.Count && pos.j >= 0 && pos.j < input.First().Length;
    }

    private static bool IsSymbol(char c)
    {
        return c is '*' or '#' or '+' or '$' or '/' or '@' or '=' or '%' or '-' or '&';
    }

    private static List<(int i, int j)> GetPositions(List<(int i, int j)> positions)
    {
        var list = new List<(int, int)>();

        foreach (var pos in positions)
        {
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    list.Add((pos.i + i, pos.j + j));
                }
            }
        }
        
        return list;
    }
}