using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using NUnit.Framework;
using Payslip.Types;

namespace Payslip.Tests.Types;

[TestFixture]
public class TaxBracketTestFixture
{
    // TODO: Missing test for invalid Dto objects. 
    [TestCaseSource(nameof(FromDto_ValidDtoObject_TestCases))]
    public void FromDto_ValidDtoObject_ShouldReturnValidTaxBracket(TaxBracketDto fromDto, TaxBracket expectedTaxBracket)
    {
        var taxBracket = TaxBracket.FromDto(fromDto);
        taxBracket.Should().BeEquivalentTo(expectedTaxBracket);
    }

    private static IEnumerable<object[]> FromDto_ValidDtoObject_TestCases()
    {
        yield return new object[]
        {
            new TaxBracketDto()
                { LowerLimit = 1, UpperLimit = 5, LumpTaxInDollars = 15, TaxInDollarsPerDollar = 0.37m },
            new TaxBracket(1, 5, 15, 0.37m)
        };

        yield return new object[]
        {
            new TaxBracketDto()
                { LowerLimit = 180001, UpperLimit = null, LumpTaxInDollars = 54547, TaxInDollarsPerDollar = 0.45m },
            new TaxBracket(180001, Decimal.MaxValue, 54547, 0.45m)
        };
    }

    [TestCase(9, false)]
    [TestCase(10, true)]
    [TestCase(15, true)]
    [TestCase(20, true)]
    [TestCase(21, false)]
    public void IsInBracket_ShouldReturnExpectedResponse(int salary, bool expectedIsInBracketResponse)
    {
        var taxBracket = new TaxBracket(10, 20, 5, 0.5m);
        taxBracket.IsInBracket(new AnnualSalary(salary)).Should().Be(expectedIsInBracketResponse);
    }

    [TestCase(37000, 0)]
    [TestCase(37001, 3572.325)]
    [TestCase(60050, 11063.25)]
    public void CalculateTax_ShouldReturnExpectedValues(int salary, decimal expectedTax)
    {
        var taxBracket = new TaxBracket(37001, 80000, 3572, 0.325m);

        taxBracket.CalculateTax(new AnnualSalary(salary)).Should().Be(expectedTax);
    }
}