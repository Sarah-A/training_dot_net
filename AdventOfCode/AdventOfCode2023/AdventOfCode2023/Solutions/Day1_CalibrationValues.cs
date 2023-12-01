namespace AdventOfCode2023;

public class Day1_CalibrationValues
{
    public int Calculate(string filePath)
    {
        var totalValue = 0;
        using (var reader = new StreamReader(filePath))
        {
            while (reader.ReadLine() is { } line)
            {
                totalValue += GetLineValue(line);
            }
        }

        return totalValue;
    }

    private int GetLineValue(string line)
    {
        var firstDigit = line.First(c => Char.IsDigit(c));
        var lastDigit = line.Last(c => Char.IsDigit(c));
        return int.Parse($"{firstDigit}{lastDigit}");
    }
}