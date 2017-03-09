using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    public class LeagueServiceByWeekImp : LeagueServiceBaseImp, LeagueService
    {
        private readonly DateTimeService dateTimeService;

        public LeagueServiceByWeekImp(IDynamicRepository repository, DateTimeService dateTimeService) : base(repository)
        {
            this.dateTimeService = dateTimeService;
        }

        protected override LeagueMappingModel Transform(LeagueRawModel rawModel)
        {
            return new LeagueMappingModel
            {
                LeagueId = rawModel.LeagueId,
                LeagueName = rawModel.LeagueName,
                Year = rawModel.Year,
                MonthOrWeek = rawModel.Week,
                WinLoss = rawModel.WinLoss,
                Turnover = rawModel.Turnover,
                BetCount = rawModel.BetCount
            };
        }

        public override IEnumerable<string> GetGroupNames(IDictionary<int, List<int>> weekGroups)
        {
            foreach (var year in weekGroups.Keys)
            {
                yield return $"Year {year}";
                var weeks = weekGroups[year];
                foreach (var week in weeks)
                {
                    var beginOfWeek = dateTimeService.GetFirstDateOfWeekISO8601(year, week);
                    yield return $"Week {week} ({beginOfWeek:MMM dd, yyyy})";
                }
            }

            if (weekGroups.Any())
            {
                yield return "Grand Total";
            }
        }
    }
}
