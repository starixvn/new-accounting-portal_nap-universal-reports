using Fanex.Data.Repository;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.DatabaseTests
{
    public static class WinLossCriteriaFactory
    {
        private const string BetTrans = "BetTrans";

        private const string BetTrans14 = "BetTrans14";

        private const string Warehouse = "Warehouse";

        public static ICriteria CreateBetTransCriteria(WinLossCriteria criteria)
        {
            criteria.Source = BetTrans;
            criteria.StartDate = BalanceUpConfiguration.BalanceUpRange.MoveBetsDate.AddDays(1);
            criteria.EndDate = BalanceUpConfiguration.BalanceUpRange.MoveBetsDate.AddDays(1);

            return criteria;
        }

        public static ICriteria CreateBetTrans14Criteria(WinLossCriteria criteria)
        {
            criteria.Source = BetTrans14;
            criteria.StartDate = BalanceUpConfiguration.BalanceUpRange.BalanceUpDate;
            criteria.EndDate = BalanceUpConfiguration.BalanceUpRange.MoveBetsDate;

            return criteria;
        }

        public static ICriteria CreateWarehouseCriteria(WinLossCriteria criteria)
        {
            criteria.Source = Warehouse;
            criteria.StartDate = BalanceUpConfiguration.BalanceUpRange.BalanceUpDate.AddDays(-1);
            criteria.EndDate = BalanceUpConfiguration.BalanceUpRange.BalanceUpDate.AddDays(-1);

            return criteria;
        }
    }
}