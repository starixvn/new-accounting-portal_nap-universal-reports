using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Parlay.Site
{
    public interface WinLossService
    {
        SiteParlayModel Query(WinLossCriteria criteria);
    }
}