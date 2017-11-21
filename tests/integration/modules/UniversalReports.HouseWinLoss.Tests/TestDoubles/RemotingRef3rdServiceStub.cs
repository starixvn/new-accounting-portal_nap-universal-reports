using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Tests.TestDoubles
{
    public class RemotingRef3rdServiceStub : RemotingRef3rdServiceImp
    {
        public override string GetLeagueName(int leagueId)
        {
            return $"Bullfighting - League {leagueId}";
        }

        public override string GetTeamName(int teamId)
        {
            return $"Team {teamId}";
        }
    }
}
