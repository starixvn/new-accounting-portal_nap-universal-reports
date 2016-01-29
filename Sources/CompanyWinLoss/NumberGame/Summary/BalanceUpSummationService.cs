using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.NumberGame.Summary
{
    public interface BalanceUpSummationService
    {
        IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources);
    }
}