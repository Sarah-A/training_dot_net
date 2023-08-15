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
        var action = () => new Salary(0);
        action.Should().Throw<Exception>();
    }
    
    [Test]
    public void Salary_NegativeSalary_ShouldThrowsException()
    {
        var action = () => new Salary(-5);
        action.Should().Throw<Exception>();
    }
    
    [Test]
    public void Salary_PositiveSalary_ShouldInitializeCorrectly()
    {
        var salary = new Salary(5);
        salary.Value.Should().Be(5);
    }
}