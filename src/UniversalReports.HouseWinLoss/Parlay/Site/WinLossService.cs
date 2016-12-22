using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Parlay.Site
{
    public interface WinLossService
    {
        SiteParlayModel Query(WinLossCriteria criteria);
    }
}