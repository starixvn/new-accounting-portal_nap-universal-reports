namespace UniversalReports.CompanyWinLoss.Tests.Soccer.MajorAndMinorSportTypes
{
    using Common;
    using CompanyWinLoss.Common.Criteria;
    using CompanyWinLoss.Soccer.MajorMinor;
    using NUnit.Framework;

    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SoccerMajorMinorServiceTests : BasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            return new Criteria
            {
                StartDate = CompanyWinLossParameters.BalanceUpDate.AddDays(-1),
                EndDate = CompanyWinLossParameters.MoveBetsDate.AddDays(1),
                IsLive = 2
            };
        }
    }
}
