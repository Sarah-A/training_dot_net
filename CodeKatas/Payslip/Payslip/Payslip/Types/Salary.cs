namespace Payslip.Types;

public class Salary
{
    public decimal Value { get; }

    public Salary(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"Salary must be a positive integer but received: {value}");
        }

        Value = value;
    }
}
