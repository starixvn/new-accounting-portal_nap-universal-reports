using Fanex.Repository;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Common.Services
{
    public class RawWinLossServiceImp : RawWinLossService
    {
        private readonly SimpleRepository repository;

        private readonly BalanceUpSourceChooser balanceUpSourceChooser;

        public RawWinLossServiceImp(SimpleRepository repository, BalanceUpSourceChooser balanceUpSourceChooser)
        {
            this.repository = repository;
            this.balanceUpSourceChooser = balanceUpSourceChooser;
        }

        public virtual List<WinLossRaw> Query(WinLossCriteria criteria)
        {
            criteria.Source = balanceUpSourceChooser.Determine(criteria);
            return repository.Fetch<WinLossRaw>(criteria).ToList();
        }
    }
}