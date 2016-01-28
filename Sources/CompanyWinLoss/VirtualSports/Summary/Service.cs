using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.VirtualSports.Summary
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}