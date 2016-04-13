using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.Sportsbook.MatchDetail;
using UniversalReports.CompanyWinLoss.Tests.Common;
using CommonService = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.MetricGamingSportsbook.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
    public class SportsbookMatchDetailServiceTests : BaseServiceTests
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
                BetType = 1,
                SportType = 1,
                IsLive = 2,
                IsHedge = false
            };
        }

        private MatchDetailWinLossServiceImp CreateService()
        {
            var rawWinLossService = CreateMatchDetailRawService();
            var remotingRefService = Substitute.For<CommonService.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns("Any team name");
            var calculationService = new MatchDetailCalculationServiceImp(remotingRefService);
            return new MatchDetailWinLossServiceImp(rawWinLossService, calculationService);
        }

        private MatchDetailRawWinLossService CreateMatchDetailRawService()
        {
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpServiceImp(dynamicRepository);
            var balanceUpSourceChooser = new BalanceUpSourceChooserImp(balanceUpService);

            var balanceUpSummationService = new MatchDetailBalanceUpSummationServiceImp();
            return new MatchDetailRawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
        }
    }
}
