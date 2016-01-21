using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class NumberGameMatchDetailWinLossServiceImp : NumberGameMatchDetailWinLossService
    {
        private RawWinLossService _rawWinLossService;

        private CalculationService _calculationService;

        public NumberGameMatchDetailWinLossServiceImp(
            RawWinLossService rawWinLossService,
            CalculationService calculationService)
        {
            _rawWinLossService = rawWinLossService;
            _calculationService = calculationService;
        }

        public NumberGameMatchDetailWinLoss Query(WinLossCriteria criteria)
        {
            var rawWinLosses = _rawWinLossService.Query(criteria);

            var leagues = rawWinLosses.Select(l => l.GroupName).Distinct();
            var leagueWinLosses = leagues.Select(l => CalculateLeagueWinLoss(l, rawWinLosses));
            var rawGrandTotal = _calculationService.CalculateSum(rawWinLosses);
            var grandTotal = _calculationService.FromRawWinLoss(rawGrandTotal);
            grandTotal.GroupName = string.Empty;

            return new NumberGameMatchDetailWinLoss
            {
                Leagues = leagueWinLosses.ToList(),
                Total = grandTotal
            };
        }

        private NumberGameLeagueWinLoss CalculateLeagueWinLoss(string league, IEnumerable<RawWinLoss> rawWinLosses)
        {
            var rawLeagueWinLosses = rawWinLosses.Where(r => r.GroupName == league);
            var matchWinLosses = rawLeagueWinLosses.Select(m => _calculationService.FromRawWinLoss(m));
            return new NumberGameLeagueWinLoss
            {
                LeagueName = league,
                Matches = matchWinLosses.ToList()
            };
        }
    }
}
