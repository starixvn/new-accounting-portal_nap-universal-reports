namespace UniversalReports.CompanyWinLoss.Tests.Soccer.MajorOrMinorBetTypes
{
    using Common;
    using CompanyWinLoss.Common.Criteria;
    using CompanyWinLoss.Soccer.MajorOrMinorBetTypes;
    using NUnit.Framework;

    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SoccerBetTypeServiceTests : BaseBasicWinLossServiceTests
    {
        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();
            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-1),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(1),
                IsLive = 2,
                IsMajor = true
            };
        }
    }
}
