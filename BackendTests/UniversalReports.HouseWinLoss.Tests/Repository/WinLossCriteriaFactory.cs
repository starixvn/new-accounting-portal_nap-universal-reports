using Fanex.Data.Repository;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Tests.Repository
{
    public static class WinLossCriteriaFactory
    {
        private const string BetTrans = "BetTrans";

        private const string BetTrans14 = "BetTrans14";

        private const string Warehouse = "Warehouse";

        public static ICriteria CreateBetTransCriteria(WinLossCriteria criteria)
        {
            criteria.Source = BetTrans;
            criteria.StartDate = RepositoryContext.MoveBetsDate.AddDays(1);
            criteria.EndDate = RepositoryContext.MoveBetsDate.AddDays(1);

            return criteria;
        }

        public static ICriteria CreateBetTrans14Criteria(WinLossCriteria criteria)
        {
            criteria.Source = BetTrans14;
            criteria.StartDate = RepositoryContext.BalanceUpDate;
            criteria.EndDate = RepositoryContext.MoveBetsDate;

            return criteria;
        }

        public static ICriteria CreateWarehouseCriteria(WinLossCriteria criteria)
        {
            criteria.Source = Warehouse;
            criteria.StartDate = RepositoryContext.BalanceUpDate.AddDays(-1);
            criteria.EndDate = RepositoryContext.BalanceUpDate.AddDays(-1);

            return criteria;
        }
    }
}