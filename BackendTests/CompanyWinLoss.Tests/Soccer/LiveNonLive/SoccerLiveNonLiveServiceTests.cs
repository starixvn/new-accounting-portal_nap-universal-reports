namespace UniversalReports.CompanyWinLoss.Tests.Soccer.LiveAndNonLiveSportTypes
{
    using Common;
    using CompanyWinLoss.Common.Criteria;
    using CompanyWinLoss.Soccer.LiveNonLive;
    using NUnit.Framework;

    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SoccerLiveNonLiveServiceTests : BasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1)
            };
        }
    }
}
