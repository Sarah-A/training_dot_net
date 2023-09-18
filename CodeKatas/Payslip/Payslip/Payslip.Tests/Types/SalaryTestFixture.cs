using FluentAssertions;
using NUnit.Framework;
using Payslip.Types;

namespace Payslip.Tests.Types;

[TestFixture]
public class SalaryTestFixture
{
    [Test]
    public void Salary_ZeroSalary_ShouldThrowsException()
    {
        var action = () => new AnnualSalary(0);
        action.Should().Throw<Exception>();
    }
    
    [Test]
    public void Salary_NegativeSalary_ShouldThrowsException()
    {
        var action = () => new AnnualSalary(-5);
        action.Should().Throw<Exception>();
    }
    
    [Test]
    public void Salary_PositiveSalary_ShouldInitializeCorrectly()
    {
        var salary = new AnnualSalary(5);
        salary.Value.Should().Be(5);
    }
}