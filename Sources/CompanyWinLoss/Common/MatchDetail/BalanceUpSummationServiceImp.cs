using System.Collections.Generic;
using System.Linq;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetail
{
    public class BalanceUpSummationServiceImp : BalanceUpSummationService
    {
        public IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources)
        {
            var allSources = sources.SelectMany(s => s);
            return allSources
                .GroupBy(l => new { l.MatchId, l.MatchCode, l.IsNeutral, l.HomeId, l.AwayId, l.LeagueId, l.HomeName, l.AwayName })
                .Select(g => new RawWinLoss
                {
                    MatchId = g.Key.MatchId,
                    MatchCode = g.Key.MatchCode,
                    IsNeutral = g.Key.IsNeutral,
                    HomeId = g.Key.HomeId,
                    AwayId = g.Key.AwayId,
                    HomeName = g.Key.HomeName,
                    AwayName = g.Key.AwayName,
                    LeagueId = g.Key.LeagueId,
                    MemberWinLoss = g.Sum(r => r.MemberWinLoss),
                    SMAWinLoss = g.Sum(r => r.SMAWinLoss),
                    Commission = g.Sum(r => r.Commission),
                    RealIncome = g.Sum(r => r.RealIncome),
                    VirtualIncome = g.Sum(r => r.VirtualIncome),
                    VarianceIncome = g.Sum(r => r.VarianceIncome),
                    RealTurnover = g.Sum(r => r.RealTurnover),
                    VirtualTurnover = g.Sum(r => r.VirtualTurnover)
                });
        }
    }
}