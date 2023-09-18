namespace Payslip.Types;

public class RoundedPositiveInt
{
    public int Value { get; }
    
    public RoundedPositiveInt(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException($"value must be a positive integer (>=0) but received: {value}");
        }

        Value = (int)Math.Round(value, MidpointRounding.AwayFromZero);
    }

    public static explicit operator RoundedPositiveInt(int a)
    {
        return new RoundedPositiveInt(a);
    }
    
    public static explicit operator RoundedPositiveInt(decimal a)
    {
        return new RoundedPositiveInt(a);
    }
}