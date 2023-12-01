namespace AdventOfCode;

public class Reader
{
    private readonly string _pathRootFolder = System.IO.Path.Combine(System.AppContext.BaseDirectory, @"..\..\..");
    public IEnumerable<string> ReadLines(int day, string fileName)
    {
        try
        {
            var directory = @$"Days\Day{day}";
            var filePath = Path.Combine(_pathRootFolder, directory, fileName);
            Console.WriteLine(filePath);
            return File.ReadAllLines(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Reading lines failed\n{ex.Message}");
        }

        return Array.Empty<string>();
    }
}