namespace UniversalReports.CompanyWinLoss.Tests.Soccer.MajorOrMinorBetTypes
{
    using Common;
    using CompanyWinLoss.Soccer.MajorOrMinorBetTypes;
    using CompanyWinLoss.Common.Criteria;
    using NUnit.Framework;

    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    class ServiceTests : BaseBasicWinLossServiceTests
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
