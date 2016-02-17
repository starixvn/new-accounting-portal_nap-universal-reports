using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.LiveCasino.BetType
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
