using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface BalanceUpService
    {
        void ClearCache();

        BalanceUpRange Query();
    }
}