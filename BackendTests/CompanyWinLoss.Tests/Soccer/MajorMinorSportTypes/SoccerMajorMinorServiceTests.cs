namespace UniversalReports.CompanyWinLoss.Tests.Soccer.MajorAndMinorSportTypes
{
    using Common;
    using CompanyWinLoss.Soccer.MajorMinorSportTypes;
    using CompanyWinLoss.Common.Criteria;
    using NUnit.Framework;

    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    class SoccerMajorMinorServiceTests : BaseBasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();
            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1),
                IsLive = 2
            };
        }
    }
}
