using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail
{
    public interface BalanceUpSummationService
    {
        IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources);
    }
}