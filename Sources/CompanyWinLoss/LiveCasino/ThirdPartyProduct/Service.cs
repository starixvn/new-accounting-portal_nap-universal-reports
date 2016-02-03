using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.LiveCasino.ThirdPartyProduct
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}
