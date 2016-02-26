using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
