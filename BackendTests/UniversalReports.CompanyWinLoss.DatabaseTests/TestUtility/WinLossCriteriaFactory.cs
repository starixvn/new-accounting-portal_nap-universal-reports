using Fanex.Data.Repository;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.DatabaseTests.TestUtility
{
    public static class WinLossCriteriaFactory
    {
        private const string BetTrans = "BetTrans";

        private const string BetTrans14 = "BetTrans14";

        private const string Warehouse = "Warehouse";

        public static ICriteria CreateBetTransCriteria(WinLossCriteria criteria)
        {
            criteria.Source = BetTrans;
            criteria.StartDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1);
            criteria.EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1);

            return criteria;
        }

        public static ICriteria CreateBetTrans14Criteria(WinLossCriteria criteria)
        {
            criteria.Source = BetTrans14;
            criteria.StartDate = CompanyWinLossParameters.BalanceUpDate;
            criteria.EndDate = CompanyWinLossParameters.MoveBetsDate;

            return criteria;
        }

        public static ICriteria CreateWarehouseCriteria(WinLossCriteria criteria)
        {
            criteria.Source = Warehouse;
            criteria.StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1);
            criteria.EndDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1);

            return criteria;
        }
    }
}
