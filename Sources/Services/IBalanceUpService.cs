using NAP.Reports.CompanyWinLoss.Models;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public interface IBalanceUpService
    {
        void ClearCache();

        BalanceUpRange Query();
    }
}