using UniversalReports.CompanyWinLoss.Common.BasicWinLoss;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Soccer.MajorOrMinorBetTypes
{
    public interface WinLossService
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
