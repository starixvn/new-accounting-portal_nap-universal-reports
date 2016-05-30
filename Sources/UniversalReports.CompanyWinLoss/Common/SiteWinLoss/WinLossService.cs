using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.SiteWinLoss
{
    public interface WinLossService
    {
        SiteWinLossModel Query(WinLossCriteria criteria);
    }
}