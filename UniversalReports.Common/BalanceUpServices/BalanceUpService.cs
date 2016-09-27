namespace UniversalReports.Common.BalanceUpServices
{
    public interface BalanceUpService
    {
        void ClearCache();

        BalanceUpRange Query();
    }
}