using System.Collections.Generic;
using System.Linq;

namespace UniversalReports.CompanyWinLoss.NumberGame.BetType
{
    public class BalanceUpSummationServiceImp : BalanceUpSummationService
    {
        public IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources)
        {
            var allSources = sources.SelectMany(s => s);
            return allSources
                .GroupBy(l => new { l.IsLive, l.GroupId, l.GroupName, l.RowName })
                .Select(g => new RawWinLoss
                {
                    IsLive = g.Key.IsLive,
                    GroupId = g.Key.GroupId,
                    GroupName = g.Key.GroupName,
                    RowName = g.Key.RowName,
                    MemberWinLoss = g.Sum(r => r.MemberWinLoss),
                    SMAWinLoss = g.Sum(r => r.SMAWinLoss),
                    Commission = g.Sum(r => r.Commission),
                    RealIncome = g.Sum(r => r.RealIncome),
                    RealTurnover = g.Sum(r => r.RealTurnover),
                    VirtualIncome = g.Sum(r => r.VirtualIncome),
                    VirtualTurnover = g.Sum(r => r.VirtualTurnover)
                });
        }
    }
}