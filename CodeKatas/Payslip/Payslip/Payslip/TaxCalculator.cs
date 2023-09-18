using System.Security.Cryptography.X509Certificates;
using Payslip.Types;

namespace Payslip;

public class TaxCalculator
{
    private readonly List<TaxBracket> taxBrackets;

    public TaxCalculator(List<TaxBracket> taxBrackets)
    {
        this.taxBrackets = taxBrackets;
    }

    public RoundedPositiveInt CalculateTax(AnnualSalary annualSalary, PayPeriod payPeriod)
    {
        var taxBracket = taxBrackets
            .Single(taxBracket => taxBracket.IsInBracket(annualSalary));
            
        var totalTax =  (taxBracket.CalculateTax(annualSalary) / 12) * payPeriod.GetPeriodInMonths();
        return new RoundedPositiveInt(totalTax);
    }
    
}