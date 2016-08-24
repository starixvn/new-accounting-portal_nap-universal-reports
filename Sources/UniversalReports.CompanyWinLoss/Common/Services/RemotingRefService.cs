namespace UniversalReports.CompanyWinLoss.Common.Services
{
    public interface RemotingRefService
    {
        string GetTeamName(int teamId, string defaultName);

        string GetLeagueName(int leagueId);
    }
}