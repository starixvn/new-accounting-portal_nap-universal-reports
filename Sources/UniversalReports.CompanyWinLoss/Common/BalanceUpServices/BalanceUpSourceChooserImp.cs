using System;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.Common.BalanceUpServices
{
    public class BalanceUpSourceChooserImp : BalanceUpSourceChooser
    {
        private const string BetTrans = "BetTrans";

        private const string BetTrans14 = "BetTrans14";

        private const string Warehouse = "Warehouse";

        private readonly BalanceUpService balanceUpService;

        public BalanceUpSourceChooserImp(BalanceUpService balanceUpService)
        {
            this.balanceUpService = balanceUpService;
        }

        public string Determine(WinLossCriteria criteria)
        {
            return criteria.NormalMode
                 ? GetBalanceUpSource(criteria.StartDate)
                 : Warehouse;
        }

        private string GetBalanceUpSource(DateTime date)
        {
            var balanceUpRange = balanceUpService.Query();

            if (date > balanceUpRange.MoveBetsDate)
            {
                return BetTrans;
            }
            else if (date >= balanceUpRange.BalanceUpDate)
            {
                return BetTrans14;
            }
            else
            {
                return Warehouse;
            }
        }
    }
}