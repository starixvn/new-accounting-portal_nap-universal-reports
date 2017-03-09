using System.Collections.Generic;
using System.Linq;

namespace UniversalReports.PunterAnalysis.League.Model
{
    public class LeagueModel
    {
        public string LeagueName { get; set; }

        public List<PeriodGroup> PeriodGroups { get; set; }

        public static LeagueModel operator +(LeagueModel firstObject, LeagueModel secondObject)
        {
            return new LeagueModel
            {
                LeagueName = string.Empty,
                PeriodGroups = firstObject.PeriodGroups.Zip(secondObject.PeriodGroups, (a, b) => a + b).ToList()
            };
        }
    }
}
