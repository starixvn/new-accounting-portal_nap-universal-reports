namespace UniversalReports.CompanyWinLoss.Tests.Soccer.MajorOrMinorBetTypes
{
    using Common;
    using CompanyWinLoss.Common.Criteria;
    using CompanyWinLoss.Soccer.BetType;
    using NUnit.Framework;

    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SoccerBetTypeServiceTests : BaseServiceTests
    {
        [Test]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = CreateService();

            // Act
            service.Query(criteria);
        }

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

        private WinLossServiceImp CreateService()
        {
            var rawWinLossService = CreateRawWinLossService();
            var calculationService = new CalculationServiceImp();
            return new WinLossServiceImp(rawWinLossService, calculationService);
        }
    }
}
