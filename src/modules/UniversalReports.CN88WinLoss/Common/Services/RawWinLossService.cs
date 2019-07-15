using System.Collections.Generic;
using System.Linq;
using Fanex.Data.Repository;
using UniversalReports.CN88WinLoss.Common.BalanceUpServices;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Common.Services
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