using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Soccer.SumBetType
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
