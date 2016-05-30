using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public interface CalculationService
    {
        decimal CalculateMargin(decimal turnover, decimal income);

        IEnumerable<LeagueWinLoss> CalculateLeagues(IEnumerable<RawWinLoss> rawWinLoss);

        LeagueWinLoss CalculateLeague(IEnumerable<RawWinLoss> rawWinLoss, int leagueId);

        WinLoss CalculateSumWinLoss(IEnumerable<RawWinLoss> rawWinLosses);

        WinLoss FromRawWinLoss(RawWinLoss rawWinLoss);

        IEnumerable<WinLoss> CalculateRM(IEnumerable<RawWinLoss> rawWinLosses);

        IEnumerable<WinLoss> CalculateMatches(IEnumerable<RawWinLoss> rawWinLoss);
    }
}