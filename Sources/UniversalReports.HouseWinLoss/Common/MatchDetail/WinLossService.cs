using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}