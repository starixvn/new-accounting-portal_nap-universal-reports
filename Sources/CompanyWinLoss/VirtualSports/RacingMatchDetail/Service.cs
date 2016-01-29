using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.RacingMatchDetail
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}