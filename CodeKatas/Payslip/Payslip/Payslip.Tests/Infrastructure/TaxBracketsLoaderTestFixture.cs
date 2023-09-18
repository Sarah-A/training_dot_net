using FluentAssertions;
using Payslip.Infrastructure;
using Payslip.Types;

namespace Payslip.Tests.Infrastructure;

[TestFixture]
public class TaxBracketsLoaderTestFixture
{
    private readonly List<TaxBracket> expectedTaxBrackets = new List<TaxBracket>()
    {
        new TaxBracket(0, 18200, 0, 0),
        new TaxBracket(18201, 37000, 0, 0.19m),
        new TaxBracket( 37001, 80000, 3572, 0.325m),
        new TaxBracket( 80001, 180000, 17547, 0.37m),
        new TaxBracket( 180001, Decimal.MaxValue, 54547,  0.45m)
    };
    
    [Test]
    public void LoadTaxBrackets_ValidFile_ShouldLoadSuccessfully()
    {
        var taxBrackets = TaxBracketsLoader.LoadTaxBrackets("../../../TestFiles/TaxBrackets.csv");
        taxBrackets.Should().BeEquivalentTo(expectedTaxBrackets);
    }
}