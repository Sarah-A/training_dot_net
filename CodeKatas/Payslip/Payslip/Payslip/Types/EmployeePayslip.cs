namespace Payslip.Types;

public class EmployeePayslip
{
    public Employee Employee { get; }
    public PayPeriod PayPeriod { get; }

    EmployeePayslip(Employee employee)
    {
        this.Employee = employee with { FirstName = "james" };
    }

}