using RemotingRef;

namespace UniversalReports.HouseWinLoss.Common.Services
{
    public class RemotingRefServiceImp : RemotingRefService
    {
        public string GetTeamName(int teamId, string defaultName = "")
        {
            var teamIdString = teamId.ToString();
            return RefData.GetTeamName(teamIdString, "en", defaultName);
        }

        public string GetLeagueName(int leagueId)
        {
            var leagueIdString = leagueId.ToString();
            return RefData.GetLeagueName(leagueIdString, "en", string.Empty);
        }
    }
}