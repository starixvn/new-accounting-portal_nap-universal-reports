using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public interface CalculationService
    {
        decimal CalulationMargin(decimal realIncome, decimal turnOver);

        IEnumerable<ArenaWinLoss> Arenas(IEnumerable<RawWinLoss> rawWinLoss);

        ArenaWinLoss CalculationArena(IEnumerable<RawWinLoss> rawWinLoss, int arenaId);

        RawWinLoss CalculationSum(IEnumerable<RawWinLoss> rawWinLoss);

        WinLoss FromRawWinLoss(RawWinLoss winLoss);
    }
}