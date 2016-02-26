using Fanex.Data.Configuration;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;
using commonService = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.Cockfighting.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class ServiceTests : BaseServiceTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        public void Query()
        {
            // Arrange
            var criteria = CreateCriteria();
            var service = CreateService();

            // Act
            service.Query(criteria);
        }

        private ServiceImp CreateService()
        {
            var rawWinLossService = CreateRawService();
            var remotingRefService = Substitute.For<commonService.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>()).Returns("Any Arena");
            var calculationService = new CalculationServiceImp(remotingRefService);
            return new ServiceImp(rawWinLossService, calculationService);
        }

        private WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2)
            };
        }

        private RawWinLossService CreateRawService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new commonService.BalanceUpServiceImp(dynamicRepository);
            var balanceUpSourceChooser = new commonService.BalanceUpSourceChooserImp(balanceUpService);

            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            return new RawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
        }
    }
}
