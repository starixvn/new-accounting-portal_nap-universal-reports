using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailByCode
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}