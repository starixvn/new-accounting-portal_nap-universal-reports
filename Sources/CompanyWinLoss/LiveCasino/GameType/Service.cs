using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.LiveCasino.GameType
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
