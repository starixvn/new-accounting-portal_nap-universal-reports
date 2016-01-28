using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class RawWinLossServiceImp : RawWinLossService
    {
        private readonly IDynamicRepository _repository;

        private readonly BalanceUpSummationService _balanceUpSummationService;

        private readonly BalanceUpSourceChooser _balanceUpSourceChooser;

        public RawWinLossServiceImp(IDynamicRepository repository, BalanceUpSummationService balanceUpSummationService, BalanceUpSourceChooser balanceUpSourceChooser)
        {
            _repository = repository;
            _balanceUpSummationService = balanceUpSummationService;
            _balanceUpSourceChooser = balanceUpSourceChooser;
        }

        public virtual List<RawWinLoss> Query(WinLossCriteria criteria)
        {
            var sources = _balanceUpSourceChooser.Determine(criteria.StartDate, criteria.EndDate).ToArray();
            var tasks = sources.Select(s => QueryBySourceAsync(s, criteria)).ToList();
            tasks.ForEach(t => t.Wait());

            var winlossesBySources = tasks.Select(t => t.Result);
            return _balanceUpSummationService.CalculateSum(winlossesBySources).ToList();
        }

        public virtual List<RawWinLoss> QueryBySource(BalanceUpSource source, WinLossCriteria criteria)
        {
            var executingCriteria = criteria.Clone(source);
            return _repository.Fetch<RawWinLoss>(executingCriteria).ToList();
        }

        public async Task<List<RawWinLoss>> QueryBySourceAsync(BalanceUpSource source, WinLossCriteria criteria)
        {
            return await Task.Run(() => QueryBySource(source, criteria)).ConfigureAwait(false);
        }
    }
}
