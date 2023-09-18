using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Payslip.Types;

public class SuperRatePercentage
{
    private const decimal MinimumSuperRate = 0;
    private const decimal MaximumSuperRate = 50;
    public decimal Value { get; }
    
    public SuperRatePercentage(string superRateInput)
    {
        const string DecimalPercentagePattern = @"([-+]?\d+[.]?\d*)%";
        var match = Regex.Match(superRateInput, DecimalPercentagePattern);

        if (!match.Success || !decimal.TryParse(match.Groups[1].Value, out var superRate))
        {
            throw new ArgumentException(
                $"Invalid input format. Expected: [percentage in decimal]% but received: {superRateInput}");
        }
    
        if (superRate < MinimumSuperRate || superRate > MaximumSuperRate)
        {
            throw new ArgumentException(
                $"Super Rate Percentage must be between {MinimumSuperRate}% and {MaximumSuperRate}% but received: {superRateInput}");
        }

        Value = superRate / 100;
    }
    
    public RoundedPositiveInt CalculateSuper(RoundedPositiveInt grossMonthlyIncome)
    {
        return new RoundedPositiveInt((decimal)grossMonthlyIncome.Value * Value);
    }
}