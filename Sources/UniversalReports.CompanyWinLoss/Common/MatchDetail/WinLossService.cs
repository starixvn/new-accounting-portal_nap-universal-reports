using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}