using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}