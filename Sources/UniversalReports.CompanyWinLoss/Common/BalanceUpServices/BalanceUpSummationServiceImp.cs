using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.BalanceUpServices
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
                    VirtualIncome = g.Sum(r => r.VirtualIncome),
                    VarianceIncome = g.Sum(r => r.VarianceIncome),
                    ExtraPT = g.Sum(r => r.ExtraPT),
                    AfterExtraPT = g.Sum(r => r.AfterExtraPT),
                    RealTurnover = g.Sum(r => r.RealTurnover),
                    VirtualTurnover = g.Sum(r => r.VirtualTurnover)
                });
        }
    }
}