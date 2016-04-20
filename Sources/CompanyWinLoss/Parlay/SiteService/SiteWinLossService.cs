using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Parlay.SiteService
{
    public interface SiteWinLossService
    {
        SiteParlayModel Query(WinLossCriteria criteria);
    }
}