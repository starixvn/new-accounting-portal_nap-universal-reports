using RemotingRef;

namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public class RemotingRefServiceImp : RemotingRefService
    {
        public string GetTeamName(int teamId)
        {
            var teamIdString = teamId.ToString();
            return RefData.GetTeamName(teamIdString, "en");
        }
    }
}
