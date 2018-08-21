using Fanex.RemotingRef;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Tests.TestDoubles
{
    public class RemotingRef3rdServiceStub : RemotingRef3rdServiceImp
    {
        public RemotingRef3rdServiceStub(IRemotingRefService remotingRefService) : base(remotingRefService)
        {
        }

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
