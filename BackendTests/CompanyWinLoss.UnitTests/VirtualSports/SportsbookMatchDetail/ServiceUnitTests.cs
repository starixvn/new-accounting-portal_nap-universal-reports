using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.VirtualSports.SportsbookMatchDetail;
using CommonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.VirtualSports.SportsbookMatchDetail
{
    public class ServiceUnitTests
    {
        [Test]
        [Category("CompanyWinLossUnitTests")]
        public void Query_ReturnRightMatchDetailWinLoss()
        {
            // Arrange   
            var expectedMatchDetailWinLoss = CreateExpectedMatchDetailWinLoss();
            var remotingRefService = Substitute.For<CommonServices.RemotingRefService>();
            remotingRefService.GetTeamName(Arg.Any<int>()).Returns("AnyTeam");
            var calculationService = new CalculationServiceImp(remotingRefService);
            var rawService = Substitute.For<RawService>();
            var fakeData = CreateFakeRawWinLoss();
            rawService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new ServiceImp(rawService, calculationService);
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

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            return new List<RawWinLoss>
           {
                WinLossFactory.CreateRawWinLoss("MatchCode 1", 1, 1, 100, 110, 10, 500, 900),
                WinLossFactory.CreateRawWinLoss("MatchCode 2", 2, 2, 110, 120, 11, 550, 990)
            };
        }

        private List<WinLoss> CreateExpectedMatches()
        {
            return new List<WinLoss>
            {
                WinLossFactory.CreateWinLoss("MatchCode 1", "AnyTeam", "AnyTeam", 100, 110, 10, 500,  900, 500m / 900),
                WinLossFactory.CreateWinLoss("MatchCode 2", "AnyTeam", "AnyTeam", 110, 120, 11, 550, 990, 550m / 990m)
            };
        }

        private WinLoss CreateExpectedGrandTotal()
        {
            return WinLossFactory.CreateWinLoss(null, "AnyTeam", "AnyTeam", 210, 230, 21, 1050, 1890, 1050m / 1890);
        }

        private bool AreTwoMatchDetailWinLossEqual(WinLossModel first, WinLossModel second)
        {
            if (!WinLossComparision.AreTwoWinLossEqual(first.Total, second.Total))
            {
                return false;
            }

            return WinLossComparision.AreTwoWinLossListEqual(first.Matches, second.Matches);
        }
    }
}
