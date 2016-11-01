namespace UniversalReports.Core.BalanceUpServices
{
    public interface BalanceUpService
    {
        void ClearCache();

        BalanceUpRange Query();
    }
}