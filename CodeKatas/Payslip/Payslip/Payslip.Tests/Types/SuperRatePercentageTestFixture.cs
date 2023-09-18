using FluentAssertions;
using NUnit.Framework;
using Payslip.Types;

namespace Payslip.Tests.Types;

[TestFixture]
public class SuperRatePercentageTestFixture
{
    [TestCase("-2%")]
    [TestCase("50.1%")]
    [TestCase("89%")]
    [TestCase("25 %")]
    public void SuperRatePercentage_InvalidFormat_ShouldThrowException(string superRateInput)
    {
        var action = () => new SuperRatePercentage(superRateInput);
        action.Should().Throw<Exception>();
    }
    
    [TestCase("0%", 0)]
    [TestCase("50%", 0.5)]
    [TestCase("25.5%", 0.255)]
    public void SuperRatePercentage_ValidFormat_ShouldReturnExpectedValue(string superRateInput, decimal expectedPercentage)
    {
        var percentage = new SuperRatePercentage(superRateInput);
        percentage.Value.Should().Be(expectedPercentage);
    }
    
    
    [TestCase(5004, 475)]
    public void SuperCalculator_ShouldReturnExpectedValue(int income, int expectedSuper)
    {
        var superCalculator = new SuperRatePercentage("9.5%");
        
        superCalculator.CalculateSuper((RoundedPositiveInt)income)
            .Should().BeEquivalentTo((RoundedPositiveInt)expectedSuper);
    }
}