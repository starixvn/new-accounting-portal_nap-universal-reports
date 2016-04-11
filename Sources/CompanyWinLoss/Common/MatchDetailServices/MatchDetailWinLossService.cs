using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public interface MatchDetailWinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}