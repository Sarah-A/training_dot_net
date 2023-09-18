using FluentAssertions;
using NUnit.Framework;
using Payslip.Types;

namespace Payslip.Tests.Types;

[TestFixture]
public class PayPeriodTestFixture
{
    [TestCase("01 March - 01 April")]
    [TestCase("01 March-31 March")]
    [TestCase("01 March 2023 - 31 March")]
    public void PayPeriod_InvalidFormat_ShouldThrowException(string payPeriodInput)
    {
        var action = () => new PayPeriod(payPeriodInput);
        action.Should().Throw<Exception>();
    }
    
    [TestCase("01 March - 31 March", 1)]
    [TestCase("1 march - 31 march", 1)]
    [TestCase("16 April - 30 April", 0.5)]
    [TestCase("16 April - 18 April", 0.1)]
    public void GetPeriodInMonths_ValidFormat_ShouldReturnExpectedPeriod(string payPeriodInput, decimal expectedPeriodInMonths)
    {
        var payPeriod = new PayPeriod(payPeriodInput);
        payPeriod.GetPeriodInMonths().Should().Be(expectedPeriodInMonths);
    }

}