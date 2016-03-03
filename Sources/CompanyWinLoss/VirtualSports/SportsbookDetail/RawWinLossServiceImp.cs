using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    public class RawWinLossServiceImp : RawWinLossService
    {
        private readonly IDynamicRepository repository;

        private readonly BalanceUpSummationService balanceUpSummationService;

        private readonly BalanceUpSourceChooser balanceUpSourceChooser;

        public RawWinLossServiceImp(IDynamicRepository repository, BalanceUpSummationService balanceUpSummationService, BalanceUpSourceChooser balanceUpSourceChooser)
        {
            this.repository = repository;
            this.balanceUpSummationService = balanceUpSummationService;
            this.balanceUpSourceChooser = balanceUpSourceChooser;
        }

        public virtual List<RawWinLoss> Query(WinLossCriteria criteria)
        {
            var sources = balanceUpSourceChooser.Determine(criteria.StartDate, criteria.EndDate).ToArray();
            var tasks = sources.Select(s => QueryBySourceAsync(s, criteria)).ToList();
            tasks.ForEach(t => t.Wait());

            var winlossesBySources = tasks.Select(t => t.Result);
            return balanceUpSummationService.CalculateSum(winlossesBySources).ToList();
        }

        public virtual List<RawWinLoss> QueryBySource(BalanceUpSource source, WinLossCriteria criteria)
        {
            var executingCriteria = criteria.Clone(source);
            return repository.Fetch<RawWinLoss>(executingCriteria).ToList();
        }

        public async Task<List<RawWinLoss>> QueryBySourceAsync(BalanceUpSource source, WinLossCriteria criteria)
        {
            return await Task.Run(() => QueryBySource(source, criteria)).ConfigureAwait(false);
        }
    }
}