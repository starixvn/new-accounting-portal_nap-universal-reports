using System.Collections.Generic;
using System.Linq;
using Fanex.Data.Repository;
using UniversalReports.CN88WinLoss.Common.BalanceUpServices;
using UniversalReports.CN88WinLoss.Common.Criteria;

namespace UniversalReports.CN88WinLoss.Common.MatchDetail
{
    public interface RawWinLossService
    {
        List<RawWinLoss> Query(WinLossCriteria criteria);
    }

    public class RawWinLossServiceImp : RawWinLossService
    {
        private readonly IDynamicRepository repository;

        private readonly BalanceUpSourceChooser balanceUpSourceChooser;

        public RawWinLossServiceImp(
            IDynamicRepository repository,
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