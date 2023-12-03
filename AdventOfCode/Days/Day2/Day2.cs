using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days.Day2;

public class Day2 : Day
{
    public Day2(int day) : base(day)
    {
    }

    protected override object Part1(List<string> input)
    {
        var idSum = 0;

        foreach (var line in input)
        {
            var splitColon = line.Split(":");
            var id = int.Parse(splitColon[0].Substring(5));
            if (GameIsOkay(splitColon[1])) idSum += id;
        }

        return idSum;
    }

    protected override object Part2(List<string> input)
    {
        return input.Select(line => GetMultiplyCubesForCubes(line.Split(":")[1])).Sum();
    }

    private static (int red, int green, int blue) ColorCountInSubset(string subset)
    {
        var red = 0;
        var green = 0;
        var blue = 0;
            
        foreach (var cube in subset.Split(","))
        {
            var colorCount = int.Parse(cube.Trim().Split(" ")[0]);
            if (cube.Contains("red")) red += colorCount;
            if (cube.Contains("green")) green += colorCount;
            if (cube.Contains("blue")) blue += colorCount;
        }

        return (red, green, blue);
    }

    private static bool GameIsOkay(string cubes)
    {
        const int redMax = 12;
        const int greenMax = 13;
        const int blueMax = 14;
        
        foreach (var subset in cubes.Split(";"))
        {
            var (red, green, blue) = ColorCountInSubset(subset);

            if (red > redMax || green > greenMax || blue > blueMax) return false;
        }

        return true;
    }

    private static int GetMultiplyCubesForCubes(string cubes)
    {
        var redMax = 0;
        var greenMax = 0;
        var blueMax = 0;
        
        foreach (var subset in cubes.Split(";"))
        {
            var (red, green, blue) = ColorCountInSubset(subset);
            redMax = int.Max(red, redMax);
            greenMax = int.Max(green, greenMax);
            blueMax = int.Max(blue, blueMax);
        }

        return redMax * greenMax * blueMax;
    }
}