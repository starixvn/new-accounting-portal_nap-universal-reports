using System.Collections.Generic;
using System.Linq;
using Fanex.Repository;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail
{
    public class RawWinLossServiceImp : RawWinLossService
    {
        private readonly SimpleRepository repository;

        private readonly BalanceUpSourceChooser balanceUpSourceChooser;

        public RawWinLossServiceImp(
            SimpleRepository repository,
            BalanceUpSourceChooser balanceUpSourceChooser)
        {
            this.repository = repository;
            this.balanceUpSourceChooser = balanceUpSourceChooser;
        }

        public virtual List<RawWinLoss> Query(WinLossCriteria criteria)
        {
            criteria.Source = balanceUpSourceChooser.Determine(criteria);
            return repository.Fetch<RawWinLoss>(criteria).ToList();
        }
    }
}