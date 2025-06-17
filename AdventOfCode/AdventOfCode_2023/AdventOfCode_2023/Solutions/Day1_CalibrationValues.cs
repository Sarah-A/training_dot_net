using System.Text;

namespace AdventOfCode2023;

public class Day1_CalibrationValues
{
    readonly Dictionary<string, string> digitReplacements =
        new Dictionary<string, string>()
        {
            { "zero", "0" },
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" }
        };
    
    public int Calculate_Q1(string filePath)
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

    public int Calculate_Q2(string filePath)
    {
        var totalValue = 0;
        using (var reader = new StreamReader(filePath))
        {
            while (reader.ReadLine() is { } line)
            {
                var reformattedLine = TranslateLexicalValuesToDigits(line);
                totalValue += GetLineValue(reformattedLine);
            }
        }

        return totalValue;
    }

    private string TranslateLexicalValuesToDigits(string inputString)
    {
        var result = new StringBuilder();
        inputString = inputString.ToLower();

        for (var i= 0; i< inputString.Length ; i++)
        {
            if (Char.IsDigit(inputString[i]))
            {
                result.Append(inputString[i]);
            }
            else
            {
                foreach (var keyValuePair in digitReplacements)
                {
                    if (inputString.StartsWith(keyValuePair.Key))
                    {
                        result.Append(keyValuePair.Value);
                        break;
                    }
                }
            }
        }
        
        // var result = digitReplacements.Aggregate(inputString,
        //     (current, replacement) => current.Replace(replacement.Key, replacement.Value));

        return result.ToString();

    }

    private int GetLineValue(string line)
    {
        var firstDigit = line.FirstOrDefault(c => Char.IsDigit(c));
        var lastDigit = line.LastOrDefault(c => Char.IsDigit(c));
        if(firstDigit == 0 && lastDigit == 0) return 0;
        return int.Parse($"{firstDigit}{lastDigit}");
    }
}