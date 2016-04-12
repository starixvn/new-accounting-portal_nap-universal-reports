namespace UniversalReports.CompanyWinLoss.Tests.Soccer.LiveAndNonLiveSportTypes
{
    using Common;
    using CompanyWinLoss.Common.Criteria;
    using CompanyWinLoss.Soccer.LiveNonLiveSportTypes;
    using NUnit.Framework;

    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SoccerLiveNonLiveServiceTests : BaseBasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();
            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1)
            };
        }
    }
}
