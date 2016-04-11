using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public interface MatchDetailCalculationService
    {
        decimal CalculateMargin(decimal turnover, decimal income);

        IEnumerable<LeagueWinLoss> CalculateLeagues(IEnumerable<MatchDetailRawWinLoss> rawWinLoss);

        LeagueWinLoss CalculateLeague(IEnumerable<MatchDetailRawWinLoss> rawWinLoss, int leagueId);

        MatchDetailWinLoss CalculateSumWinLoss(IEnumerable<MatchDetailRawWinLoss> rawWinLosses);

        MatchDetailWinLoss FromRawWinLoss(MatchDetailRawWinLoss rawWinLoss);
    }
}