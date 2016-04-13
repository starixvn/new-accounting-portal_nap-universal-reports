using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.SiteWinLoss
{
    public interface SiteService
    {
        SiteWinLossModel Query(WinLossCriteria criteria);
    }
}