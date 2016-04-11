using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public interface MatchDetailBalanceUpSummationService
    {
        IEnumerable<MatchDetailRawWinLoss> CalculateSum(IEnumerable<IEnumerable<MatchDetailRawWinLoss>> sources);
    }
}