using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Racing.MatchDetail
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}