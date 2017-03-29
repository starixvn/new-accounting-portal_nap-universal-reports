using Fanex.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    public class LeagueServiceByMonth : LeagueServiceBase, LeagueService
    {
        public LeagueServiceByMonth(IDynamicRepository repository) : base(repository)
        {
        }

        protected override LeagueMappingModel Transform(LeagueRawModel rawModel)
        {
            return new LeagueMappingModel
            {
                LeagueId = rawModel.LeagueId,
                LeagueName = rawModel.LeagueName,
                Year = rawModel.Year,
                MonthOrWeek = rawModel.Month,
                WinLoss = rawModel.WinLoss,
                Turnover = rawModel.Turnover,
                BetCount = rawModel.BetCount
            };
        }

        public override IEnumerable<string> GetGroupNames(IDictionary<int, List<int>> monthGroups)
        {
            foreach (var year in monthGroups.Keys)
            {
                yield return $"Year {year}";
                var months = monthGroups[year];
                foreach (var month in months)
                {
                    var beginOfMonth = new DateTime(year, month, 1);
                    yield return beginOfMonth.ToString("MMMM");
                }
            }

            if (monthGroups.Any())
            {
                yield return "Grand Total";
            }
        }
    }
}
