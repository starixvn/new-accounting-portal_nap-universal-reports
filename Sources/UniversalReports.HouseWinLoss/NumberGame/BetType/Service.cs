using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.NumberGame.BetType
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}