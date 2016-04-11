using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.SportsbookDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightMatchDetailWinLoss()
        {
            // Arrange   
            var expectedMatchDetailWinLoss = CreateExpectedMatchDetailWinLoss();
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns("AnyTeam");
            var calculationService = new MatchDetailCalculationServiceImp(remotingRefService);
            var rawWinLossService = Substitute.For<MatchDetailRawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = AreTwoMatchDetailWinLossEqual(expectedMatchDetailWinLoss, result);
            Assert.True(equal);
        }

        private WinLossModel CreateExpectedMatchDetailWinLoss()
        {
            var expectedMatches = CreateExpectedMatches();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new WinLossModel
            {
                Matches = expectedMatches,
                Total = expectedGrandTotal
            };
        }

        private List<MatchDetailRawWinLoss> CreateFakeRawWinLoss()
        {
            return new List<MatchDetailRawWinLoss>
           {
                WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 100, 110, 10, 500, 900),
                WinLossFactory.CreateRawWinLoss("MatchCode 2", 2, 2, 110, 120, 11, 550, 990)
            };
        }

        private List<MatchDetailWinLoss> CreateExpectedMatches()
        {
            return new List<MatchDetailWinLoss>
            {
                WinLossFactory.CreateWinLoss("MatchCode 1", "AnyTeam", "AnyTeam", 100, 110, 10, 500,  900, 500m / 900),
                WinLossFactory.CreateWinLoss("MatchCode 2", "AnyTeam", "AnyTeam", 110, 120, 11, 550, 990, 550m / 990m)
            };
        }

        private MatchDetailWinLoss CreateExpectedGrandTotal()
        {
            return WinLossFactory.CreateWinLoss(null, "AnyTeam", "AnyTeam", 210, 230, 21, 1050, 1890, 1050m / 1890);
        }

        private bool AreTwoMatchDetailWinLossEqual(WinLossModel first, WinLossModel second)
        {
            return WinLossComparision.AreTwoWinLossEqual(first.Total, second.Total)
                && WinLossComparision.AreTwoWinLossListEqual(first.Matches, second.Matches);
        }
    }
}
