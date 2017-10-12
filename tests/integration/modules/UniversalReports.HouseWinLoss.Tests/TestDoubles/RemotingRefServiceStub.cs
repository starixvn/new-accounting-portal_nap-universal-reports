using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Tests.TestDoubles
{
    public class RemotingRefServiceStub : RemotingRefService
    {
        public string GetLeagueName(int leagueId)
        {
            return $"League {leagueId}";
        }

        public string GetTeamName(int teamId)
        {
            return $"Team {teamId}";
        }
    }
}