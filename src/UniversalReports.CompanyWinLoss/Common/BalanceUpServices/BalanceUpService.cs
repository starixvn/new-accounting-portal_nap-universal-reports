namespace UniversalReports.CompanyWinLoss.Common.BalanceUpServices
{
    public interface BalanceUpService
    {
        void ClearCache();

        BalanceUpRange Query();
    }
}