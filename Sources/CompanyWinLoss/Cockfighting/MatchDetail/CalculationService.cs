using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
