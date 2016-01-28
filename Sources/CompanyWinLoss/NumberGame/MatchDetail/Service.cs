using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}