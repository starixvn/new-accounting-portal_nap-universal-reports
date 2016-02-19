using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}