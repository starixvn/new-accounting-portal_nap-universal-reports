using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Soccer.GroupBetType
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
