using Fanex.Data.Repository;
using Fanex.Respository;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
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

        public virtual List<RawWinLoss> Query(WinLossCriteria criteria)
        {
            criteria.Source = balanceUpSourceChooser.Determine(criteria);
            return repository.Fetch<RawWinLoss>(criteria).ToList();
        }
    }
}