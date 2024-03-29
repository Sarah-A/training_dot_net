using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Payslip.Types;

namespace Payslip.Infrastructure;

// TODO: add an interface so we can support different types of Loaders (e.g. csv/db etc)
public static class TaxBracketsLoader
{
    public static List<TaxBracket> LoadTaxBrackets(string filePath)
    {
        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            MissingFieldFound = null
        };
        
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, csvConfig);
        csv.Read();
        csv.ReadHeader();
        var dtoRecords = csv.GetRecords<TaxBracketDto>().ToList();
        return dtoRecords.Select(TaxBracket.FromDto).ToList();
    }
}