using System.Collections.Generic;
using System.Linq;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail
{
    public class BalanceUpSummationServiceImp : BalanceUpSummationService
    {
        public IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources)
        {
            var allSources = sources.SelectMany(s => s);
            return allSources
                .GroupBy(l => new { l.MatchCode, l.HomeId, l.AwayId })
                .Select(g => new RawWinLoss
                {
                    MatchCode = g.Key.MatchCode,
                    HomeId = g.Key.HomeId,
                    AwayId = g.Key.AwayId,
                    MemberWinLoss = g.Sum(r => r.MemberWinLoss),
                    SMAWinLoss = g.Sum(r => r.SMAWinLoss),
                    Commission = g.Sum(r => r.Commission),
                    RealIncome = g.Sum(r => r.RealIncome),
                    RealTurnover = g.Sum(r => r.RealTurnover)
                });
        }
    }
}
