using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.MatchDetailByCode
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}