using System.Globalization;
using Payslip.Types;

namespace Payslip;

public class EmployeeDetailsDto
{
    public string FirstName { get; }
    public string LastName { get; }
    public int AnnualSalary { get; }
    public string SuperInPercents { get; }
    public string PayPeriod { get; }
}

public class EmployeeDetails
{
    public Employee Employee { get; }
    public AnnualSalary AnnualSalary { get; }
    public SuperRatePercentage SuperRateInPercents { get; }
    public PayPeriod PayPeriod { get; }

    public EmployeeDetails(string firstName, string lastName, int annualSalary, string superRateInPercents,
        string payPeriod)
    {
        Employee = new Employee(firstName, lastName);
        AnnualSalary = new AnnualSalary(annualSalary);
        SuperRateInPercents = new SuperRatePercentage(superRateInPercents);
        PayPeriod = new PayPeriod(payPeriod);
    }

    public static EmployeeDetails FromDto(EmployeeDetailsDto dto)
    {
        return new EmployeeDetails(dto.FirstName, dto.LastName, dto.AnnualSalary, dto.SuperInPercents, dto.PayPeriod);
    }
}




