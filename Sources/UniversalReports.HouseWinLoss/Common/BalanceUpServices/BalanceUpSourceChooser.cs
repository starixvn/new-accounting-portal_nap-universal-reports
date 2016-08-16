using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.BalanceUpServices
{
    public interface BalanceUpSourceChooser
    {
        string Determine(WinLossCriteria criteria);
    }
}