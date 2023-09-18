using System.Net.Mail;

namespace Payslip.Types;

public class AnnualSalary : RoundedPositiveInt
{
    public AnnualSalary(int value) : base(value)
    {
        if (Value == 0)
        {
            throw new ArgumentException($"Salary must be a positive integer but received: {value}");
        }
    }

    public RoundedPositiveInt GetMonthlyIncome()
    {
        return new RoundedPositiveInt((decimal)Value / 12m);
    }
}
