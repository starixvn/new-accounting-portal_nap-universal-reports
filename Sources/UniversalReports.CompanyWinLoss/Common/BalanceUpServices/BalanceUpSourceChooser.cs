using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.BalanceUpServices
{
    public interface BalanceUpSourceChooser
    {
        string Determine(WinLossCriteria criteria);
    }
}