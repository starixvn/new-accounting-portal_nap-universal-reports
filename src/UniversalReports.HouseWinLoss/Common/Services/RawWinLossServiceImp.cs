using System.Collections.Generic;
using System.Linq;
using Fanex.Data.Repository;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.Common.Services
{
    public interface RawWinLossService
    {
        List<WinLossRaw> Query(WinLossCriteria criteria);
    }

    public class RawWinLossServiceImp : RawWinLossService
    {
        private readonly IDynamicRepository repository;

        private readonly BalanceUpSourceChooser balanceUpSourceChooser;

        public RawWinLossServiceImp(IDynamicRepository repository, BalanceUpSourceChooser balanceUpSourceChooser)
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