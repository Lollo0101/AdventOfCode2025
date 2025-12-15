namespace AdventOfCode.Input;

public class FileInput : IInput
{
    public List<string> ReadDayOneInput()
    {
        var input = new List<string>();

        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DayOne", "Input", "input.txt");

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

    public List<string> ReadDayTwoInput()
    {
        var input = new List<string>();

        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DayTwo", "Input", "input.txt");

            var sr = new StreamReader(path);
            var line = sr.ReadLine();

            while (line is not null)
            {
                var ranges = line.Split(',');

                foreach (var range in ranges)
                {
                    input.Add(range);
                }

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

    public List<string> ReadDayThreeInput()
    {
        var input = new List<string>();

        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DayThree", "Input", "input.txt");

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

    public List<string> ReadDayFourInput()
    {
        var input = new List<string>();

        try
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DayFour", "Input", "input.txt");

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
