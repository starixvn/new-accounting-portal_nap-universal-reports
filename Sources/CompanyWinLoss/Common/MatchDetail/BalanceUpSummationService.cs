using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public interface BalanceUpSummationService
    {
        IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources);
    }
}