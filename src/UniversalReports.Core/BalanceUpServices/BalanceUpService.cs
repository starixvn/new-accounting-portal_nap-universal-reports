namespace UniversalReports.Core.BalanceUpServices
{
    public interface BalanceUpService
    {
        BalanceUpRange Query();

        BalanceUpRange QueryFromSource();
    }
}