using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}