using System.Collections.Generic;
using System.Linq;

namespace UniversalReports.PunterAnalysis.League.Model
{
    public class LeagueModel
    {
        public string LeagueName { get; set; }

        public List<PeriodGroup> PeriodGroups { get; set; }

        public static LeagueModel operator +(LeagueModel a, LeagueModel b)
        {
            return Add(a, b);
        }

        public static LeagueModel Add(LeagueModel a, LeagueModel b)
        {
            var sumPeriodGroup = a.PeriodGroups.Zip(b.PeriodGroups, (x, y) => x + y).ToList();
            return new LeagueModel
            {
                LeagueName = string.Empty,
                PeriodGroups = sumPeriodGroup
            };
        }

        public static bool operator ==(LeagueModel a, LeagueModel b)
        {
            return a.LeagueName == b.LeagueName
                && IsEqualPeriodGroups(a.PeriodGroups, b.PeriodGroups);
        }

        private static bool IsEqualPeriodGroups(List<PeriodGroup> a, List<PeriodGroup> b)
        {
            return !a.Except(b).Any();
        }

        public static bool operator !=(LeagueModel a, LeagueModel b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            var good = obj as LeagueModel;
            return obj != null && this == good;
        }
    }
}
