using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.BasicWinLoss
{
    public interface BasicWinLossService
    {
        BasicWinLossModel Query(WinLossCriteria criteria);
    }
}