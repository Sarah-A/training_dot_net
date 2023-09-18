using FluentAssertions;
using NUnit.Framework;
using Payslip.Types;

namespace Payslip.Tests.Types;

[TestFixture]
public class RoundedPositiveIntTestFixture
{
    
    [TestCase(-5)]
    [TestCase(-0.2)]
    public void RoundedPositiveInt_WhenInvalid_ShouldThrowAnException(decimal fromValue)
    {
        var action = () => new RoundedPositiveInt(fromValue);
        action.Should().Throw<Exception>();
    }


    [TestCase(0, 0)]
    [TestCase(1.0, 1)]
    [TestCase(1.4999, 1)]
    [TestCase(1.5, 2)]
    [TestCase(1.999, 2)]
    public void RoundedPositiveInt_WhenValid_ShouldReturnExpectedValue(decimal fromValue, int expectedValue)
    {
        var roundedPositiveInt = new RoundedPositiveInt(fromValue);
        roundedPositiveInt.Value.Should().Be(expectedValue);
    }

    [Test]
    public void RoundedPositiveInt_ExplicitCasting_WhenInvalid_ShouldThrowAnException()
    {
        var castFromInt = () => (RoundedPositiveInt)(-5);
        castFromInt.Should().Throw<Exception>();

        var castFromDecimal = () => (RoundedPositiveInt)(- 4.3);
        castFromDecimal.Should().Throw<Exception>();
    }
    
    [Test]
    public void RoundedPositiveInt_ExplicitCasting_WhenValid_ShouldReturnExpectedValue()
    {
        var castFromInt = (RoundedPositiveInt)5;
        castFromInt.Should().BeEquivalentTo(new RoundedPositiveInt(5));

        var castFromDecimal = (RoundedPositiveInt)4.5m;
        castFromDecimal.Should().BeEquivalentTo(new RoundedPositiveInt(4.5m));
    }
}