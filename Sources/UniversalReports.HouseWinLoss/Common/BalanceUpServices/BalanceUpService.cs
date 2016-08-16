namespace UniversalReports.HouseWinLoss.Common.BalanceUpServices
{
    public interface BalanceUpService
    {
        void ClearCache();

        BalanceUpRange Query();
    }
}