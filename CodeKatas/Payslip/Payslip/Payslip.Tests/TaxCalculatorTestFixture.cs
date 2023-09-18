using FluentAssertions;
using NUnit.Framework;
using Payslip.Types;

namespace Payslip.Tests;

[TestFixture]
public class TaxCalculatorTestFixture
{
    private static readonly List<TaxBracket> TaxBrackets = new List<TaxBracket>()
    {
        new TaxBracket(0, 18200, 0, 0),
        new TaxBracket(18201, 37000, 59, 0.19m),
        new TaxBracket( 37001, 80000, 3572, 0.325m)
    };

    private TaxCalculator taxCalculator;

    [SetUp]
    public void Setup()
    {
        this.taxCalculator = new TaxCalculator(TaxCalculatorTestFixture.TaxBrackets);
    }

    [TestCaseSource(nameof(CalculateTax_WhenValid_TestCases))]
    public void CalculateTax_WhenValid_ShouldReturnExpectedValue(int salary, PayPeriod period, int expectedTax)
    {
        taxCalculator.CalculateTax(new AnnualSalary(salary), period)
            .Should().BeEquivalentTo((RoundedPositiveInt)expectedTax);
    }

    [Test]
    public void CalculateTax_WhenInvalid_ThrowAnException()
    {
        var payPeriod = new PayPeriod("01 March - 31 March");
        var action = () => taxCalculator.CalculateTax(new AnnualSalary(80001), payPeriod);
        action.Should().Throw<Exception>();
    }

    public static IEnumerable<object[]> CalculateTax_WhenValid_TestCases()
    {
        yield return new object[]
        {
            18200, new PayPeriod("01 March - 31 March"), 0
        };

        yield return new object[]
        {
            24321, new PayPeriod("16 March - 31 March"), 53
        };

        yield return new object[]
        {
            60050, new PayPeriod("01 March - 31 March"), 922
        };
    }
}