using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Payslip.Types;

public class TaxBracketDto
{
    public decimal LowerLimit { get; set; }
    [Optional]
    public decimal? UpperLimit { get; set; }
    public decimal LumpTaxInDollars { get; set; }
    public decimal TaxInDollarsPerDollar { get; set; }
}


public class TaxBracket
{
    // TODO: Missing validation of provided parameters - assuming that 0<= lowerLimit <= upperLImit etc.
    public TaxBracket(decimal lowerLimit, decimal upperLimit, decimal lumpTaxInDollars, decimal taxInDollarsPerDollar)
    {
        this.LowerLimit = lowerLimit;
        this.UpperLimit = upperLimit;
        this.LumpTaxInDollars = lumpTaxInDollars;
        this.TaxInDollarsPerDollar = taxInDollarsPerDollar;
    }

    public decimal LowerLimit { get; }
    public decimal UpperLimit { get; }
    public decimal LumpTaxInDollars { get; }
    public decimal TaxInDollarsPerDollar { get; }


    public static TaxBracket FromDto(TaxBracketDto dto)
    {
        var upperLimit = dto.UpperLimit ?? Decimal.MaxValue;
        return new TaxBracket(dto.LowerLimit, upperLimit, dto.LumpTaxInDollars, dto.TaxInDollarsPerDollar);
    }

    public bool IsInBracket(AnnualSalary annualSalary)
    {
        return (annualSalary.Value >= LowerLimit && annualSalary.Value <= UpperLimit);
    }

    public decimal CalculateTax(AnnualSalary annualSalary)
    {
        if (!IsInBracket(annualSalary)) return 0;

        return (LumpTaxInDollars + (annualSalary.Value - LowerLimit + 1) * TaxInDollarsPerDollar);
    }
}