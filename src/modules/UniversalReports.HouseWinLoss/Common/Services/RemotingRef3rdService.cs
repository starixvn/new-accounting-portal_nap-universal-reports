using RemotingRef;

namespace UniversalReports.HouseWinLoss.Common.Services
{
    public interface RemotingRef3rdService
    {
        string Get3rdTeamName(int teamId);

        string Get3rdLeagueName(int leagueId);
    }

    public class RemotingRef3rdServiceImp : RemotingRef3rdService
    {
        public string Get3rdLeagueName(int leagueId)
        {
            var leagueIdString = leagueId.ToString();
            return RefData.GetLeagueName3rd(leagueIdString, "en", string.Empty);
        }

        public string Get3rdTeamName(int teamId)
        {
            var teamIdString = teamId.ToString();
            return RefData.GetTeamName3rd(teamIdString, "en", string.Empty);
        }
    }
}
