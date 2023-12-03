namespace AdventOfCode;

public class Reader
{
    private readonly string _pathRootFolder = System.IO.Path.Combine(System.AppContext.BaseDirectory, @"..\..\..");
    public List<string> ReadLines(int day, string fileName)
    {
        try
        {
            var directory = @$"Days\Day{day}";
            var filePath = Path.Combine(_pathRootFolder, directory, fileName);
            return File.ReadAllLines(filePath).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Reading lines failed\n{ex.Message}");
        }

        return new List<string>();
    }
}