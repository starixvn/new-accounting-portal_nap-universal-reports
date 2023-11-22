using System;
using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.Common.BalanceUpServices
{
    using UniversalReports.BalanceUpServices;

    public interface BalanceUpSourceChooser
    {
        string Determine(WinLossCriteria criteria);
    }

    public class BalanceUpSourceChooserImp : BalanceUpSourceChooser
    {
        private const string BetTrans = "BetTrans";

        private const string Warehouse = "Warehouse";

        private readonly BalanceUpService balanceUpService;

        public BalanceUpSourceChooserImp(BalanceUpService balanceUpService)
        {
            this.balanceUpService = balanceUpService;
        }

        public string Determine(WinLossCriteria criteria)
        {
            return criteria.NormalMode
                 ? GetDataSource(criteria.StartDate)
                 : Warehouse;
        }

        private string GetDataSource(DateTime date)
        {
            var balanceUpRange = balanceUpService.Query();

            return date > balanceUpRange.MoveBetsDate
                ? BetTrans
                : Warehouse;
        }
    }
}