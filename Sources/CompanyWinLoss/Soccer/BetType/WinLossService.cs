using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Soccer.BetType
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
