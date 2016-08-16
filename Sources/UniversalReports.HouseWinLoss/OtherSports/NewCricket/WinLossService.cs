using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.OtherSports.NewCricket
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
