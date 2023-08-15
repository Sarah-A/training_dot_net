using System.Globalization;

namespace Payslip.Types;

public class PayPeriod
{
    private DateTime fromDate;
    private DateTime toDate;
    
    public PayPeriod(string payPeriod)
    {
        var cultureInfo = new CultureInfo("en-AU");
        
        var dates = payPeriod.Split(" - ");
        if (dates.Length != 2)
        {
            throw new ArgumentException(
                $"PayPeriod must be in the format: \"[from date] - [to data]\". But received: {payPeriod}");
        }

        this.fromDate = DateTime.ParseExact(dates[0], "M", cultureInfo);
        this.toDate = DateTime.ParseExact(dates[1], "M", cultureInfo);

        if (fromDate.Month != toDate.Month)
        {
            throw new ArgumentException(
                $"PayPeriod must be in the same month. But received: {payPeriod}");
        }
    }

    public decimal GetPeriodInMonths()
    {
        var daysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, fromDate.Month);
        var totalDays = (toDate - fromDate).Days + 1;
        return ((decimal)totalDays / (decimal)daysInMonth );
    }

}