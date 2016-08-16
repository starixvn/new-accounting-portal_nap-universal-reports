using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.SiteWinLoss
{
    public interface WinLossService
    {
        SiteWinLossModel Query(WinLossCriteria criteria);
    }
}