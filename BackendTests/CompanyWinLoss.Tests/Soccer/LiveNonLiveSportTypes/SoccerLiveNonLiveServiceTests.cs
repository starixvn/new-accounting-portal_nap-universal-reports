namespace UniversalReports.CompanyWinLoss.Tests.Soccer.LiveAndNonLiveSportTypes
{
    using NUnit.Framework;
    using CompanyWinLoss.Soccer.LiveNonLiveSportTypes;
    using CompanyWinLoss.Common.Criteria;
    using Common;

    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    class SoccerLiveNonLiveServiceTests : BaseBasicWinLossServiceTests
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
