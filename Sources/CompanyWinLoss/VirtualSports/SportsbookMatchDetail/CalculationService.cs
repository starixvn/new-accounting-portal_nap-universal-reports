using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail
{
    public interface CalculationService
    {
        decimal CalculateMargin(decimal turnover, decimal income);

        WinLoss CalculateSumWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        WinLoss FromRawWinLoss(RawWinLoss rawWinLoss);
    }
}