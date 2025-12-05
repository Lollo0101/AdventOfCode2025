namespace AdventOfCode.Input;

public class FileInput : IInput
{
    public List<string> ReadListInput()
    {
        var input = new List<string>();

        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DayOne", "input.txt");

            var sr = new StreamReader(path);
            var line = sr.ReadLine();

            while (line is not null)
            {
                input.Add(line);
                line = sr.ReadLine();
            }

            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
            throw;
        }

        return input;
    }
}
