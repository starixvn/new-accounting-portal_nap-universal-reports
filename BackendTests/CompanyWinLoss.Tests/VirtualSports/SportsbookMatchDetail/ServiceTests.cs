using Fanex.Data.Configuration;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Tests.Common;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail;
using CommonService = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.VirtualSports.SportsbookMatchDetail
{
    public class ServiceTests : BaseServiceTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        [Category("ServiceIntegrationTests")]
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
            var rawService = CreateRawService();
            var remotingRefService = Substitute.For<CommonService.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>()).Returns("Any team name");
            var calculationService = new CalculationServiceImp(remotingRefService);
            return new ServiceImp(rawService, calculationService);
        }

        private WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2),
                BetType = 1231,
                SportType = 181
            };
        }

        private RawService CreateRawService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new CommonService.BalanceUpServiceImp(dynamicRepository);
            var balanceUpSourceChooser = new CommonService.BalanceUpSourceChooserImp(balanceUpService);

            var balanceUpSummationService = new BalanceUpSummationServiceImp();
            return new RawServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
        }
    }
}
