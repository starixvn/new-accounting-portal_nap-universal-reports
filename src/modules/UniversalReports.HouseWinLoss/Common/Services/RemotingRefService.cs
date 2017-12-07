using RemotingRef;

namespace UniversalReports.HouseWinLoss.Common.Services
{
    public interface RemotingRefService
    {
        string GetTeamName(int teamId);

        string GetLeagueName(int leagueId);
    }

    public class RemotingRefServiceImp : RemotingRefService
    {
        public string GetTeamName(int teamId)
        {
            var teamIdString = teamId.ToString();
            return RefData.GetTeamName(teamIdString, "en", string.Empty);
        }

        public string GetLeagueName(int leagueId)
        {
            var leagueIdString = leagueId.ToString();
            return RefData.GetLeagueName(leagueIdString, "en", string.Empty);
        }
    }

    public class RemotingRef3rdServiceImp : RemotingRefService
    {
        public virtual string GetLeagueName(int leagueId)
        {
            var leagueIdString = leagueId.ToString();
            return RefData.GetLeagueName3rd(leagueIdString, "en", string.Empty);
        }

        public virtual string GetTeamName(int teamId)
        {
            var teamIdString = teamId.ToString();
            return RefData.GetTeamName3rd(teamIdString, "en", string.Empty);
        }
    }
}