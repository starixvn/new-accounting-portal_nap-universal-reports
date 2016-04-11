using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.Tests.Common;
using commonService = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.Cockfighting.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class ServiceTests : BaseServiceTests
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

        private ServiceImp CreateService()
        {
            var rawWinLossService = CreateRawService();
            var remotingRefService = Substitute.For<commonService.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns("Any Arena");
            var calculationService = new MatchDetailCalculationServiceImp(remotingRefService);
            return new ServiceImp(rawWinLossService, calculationService);
        }

        protected override WinLossCriteria CreateCriteria()
        {
            var balanceUpRange = GetBalanceUpRange();

            return new Criteria
            {
                StartDate = balanceUpRange.BalanceUpDate.AddDays(-2),
                EndDate = balanceUpRange.MoveBetsDate.AddDays(2)
            };
        }

        private MatchDetailRawWinLossService CreateRawService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new commonService.BalanceUpServiceImp(dynamicRepository);
            var balanceUpSourceChooser = new commonService.BalanceUpSourceChooserImp(balanceUpService);

            var balanceUpSummationService = new MatchDetailBalanceUpSummationServiceImp();
            return new MatchDetailRawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
        }
    }
}
