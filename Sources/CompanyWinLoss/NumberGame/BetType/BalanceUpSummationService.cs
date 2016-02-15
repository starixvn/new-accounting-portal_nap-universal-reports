using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public interface BalanceUpSummationService
    {
        IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources);
    }
}