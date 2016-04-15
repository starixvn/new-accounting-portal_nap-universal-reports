using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.Dependencies
{
    public class RemotingRefServiceFake : RemotingRefService
    {
        public string GetLeagueName(int leagueId)
        {
            return string.Empty;
        }

        public string GetTeamName(int teamId, string defaultName)
        {
            return string.Empty;
        }
    }
}
