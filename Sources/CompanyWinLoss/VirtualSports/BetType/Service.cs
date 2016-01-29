using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.BetType
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}