using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Soccer.GroupBetType
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}