using System.Collections.Generic;
using System.Linq;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class BalanceUpSummationServiceImp : BalanceUpSummationService
    {
        public IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources)
        {
            var allSources = sources.SelectMany(s => s);
            return allSources
                .GroupBy(l => new { l.ArenaId, l.FightNo, l.HomeName, l.AwayName })
                .Select(g => new RawWinLoss
                {
                    FightNo = g.Key.FightNo,
                    ArenaId = g.Key.ArenaId,
                    HomeName = g.Key.HomeName,
                    AwayName = g.Key.AwayName,
                    MemberWinLoss = g.Sum(r => r.MemberWinLoss),
                    SMAWinLoss = g.Sum(r => r.SMAWinLoss),
                    Commission = g.Sum(r => r.Commission),
                    RealIncome = g.Sum(r => r.RealIncome),
                    RealTurnover = g.Sum(r => r.RealTurnover)
                });
        }
    }
}