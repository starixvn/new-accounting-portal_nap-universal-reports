using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.OtherSports.NewCricket
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
