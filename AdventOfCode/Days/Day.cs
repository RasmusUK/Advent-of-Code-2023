namespace AdventOfCode.Days;

public abstract class Day
{
    private readonly List<string> _example1;
    private readonly List<string> _example2;
    private readonly List<string> _input;
    
    protected Day(int day)
    {
        var reader = new Reader();
        _example1 = reader.ReadLines(day, "Example1.txt");
        _example2 = reader.ReadLines(day, "Example2.txt");
        _input = reader.ReadLines(day, "Input.txt");
    }

    public void Run()
    {
        Console.WriteLine($"Part1 (example / input): ({Part1(_example1)} / {Part1(_input)})\n" +
                          $"Part2 (example / input): ({Part2(_example2)} / {Part2(_input)})");
    }

    protected abstract object Part1(List<string> input);

    protected abstract object Part2(List<string> input);

    protected void PrintDebug(List<string> list)
    {
        foreach (var line in list)
        {
            Console.WriteLine(line);
        }
    }
}