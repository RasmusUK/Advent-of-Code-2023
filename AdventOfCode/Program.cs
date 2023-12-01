
using System.Reflection;

Console.WriteLine("Welcome to code of advent");

var day = 0;
var parseSuccess = false;

while (!parseSuccess)
{
    Console.WriteLine("Please enter day:");
    parseSuccess = int.TryParse(Console.ReadLine(), out day);
}

var className = $"AdventOfCode.Days.Day{day}.Day{day}";
var type = Type.GetType(className);

if (type != null)
{
    var parameters = new object[]{ day };
    var instance = Activator.CreateInstance(type, parameters);
    var method = type.GetMethod("Run");

    if (method != null)
    {
        method.Invoke(instance, null);
    }
    else
    {
        Console.WriteLine($"Method 'Run' not found in {className}");
    }
}
else
{
    Console.WriteLine($"Class {className} not found");
}