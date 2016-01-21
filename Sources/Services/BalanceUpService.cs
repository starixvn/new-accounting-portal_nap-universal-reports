using NAP.Reports.CompanyWinLoss.Models;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface BalanceUpService
    {
        void ClearCache();

        BalanceUpRange Query();
    }
}