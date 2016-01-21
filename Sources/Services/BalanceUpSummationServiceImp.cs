using NAP.Reports.CompanyWinLoss.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace NAP.Reports.CompanyWinLoss.Services
{
    public class BalanceUpSummationServiceImp : BalanceUpSummationService
    {
        public IEnumerable<RawWinLoss> CalculateSum(IEnumerable<IEnumerable<RawWinLoss>> sources)
        {
            var allSources = sources.SelectMany(s => s);
            return allSources
                .GroupBy(l => new { l.GroupId, l.GroupName, l.IsLive, l.RowName })
                .Select(g => new RawWinLoss
                {
                    GroupId = g.Key.GroupId,
                    GroupName = g.Key.GroupName,
                    RowName = g.Key.RowName,
                    IsLive = g.Key.IsLive,
                    MemberWinLoss = g.Sum(r => r.MemberWinLoss),
                    SMAWinLoss = g.Sum(r => r.SMAWinLoss),
                    Commission = g.Sum(r => r.Commission),
                    RealIncome = g.Sum(r => r.RealIncome),
                    VirtualIncome = g.Sum(r => r.VirtualIncome),
                    RealTurnover = g.Sum(r => r.RealTurnover),
                    VirtualTurnover = g.Sum(r => r.VirtualTurnover)
                });
        }
    }
}
