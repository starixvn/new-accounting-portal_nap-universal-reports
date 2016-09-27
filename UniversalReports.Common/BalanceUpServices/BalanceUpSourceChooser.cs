using UniversalReports.Common.Criteria;

namespace UniversalReports.Common.BalanceUpServices
{
    public interface BalanceUpSourceChooser
    {
        string Determine(WinLossCriteria criteria);
    }
}