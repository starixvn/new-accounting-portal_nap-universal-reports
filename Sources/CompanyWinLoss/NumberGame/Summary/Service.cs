using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.NumberGame.Summary
{
    public interface Service
    {
        WinLossModel Query(WinLossCriteria criteria);
    }
}