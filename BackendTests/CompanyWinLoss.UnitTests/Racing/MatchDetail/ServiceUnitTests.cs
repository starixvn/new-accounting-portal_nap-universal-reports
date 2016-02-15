using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Racing.MatchDetail;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Racing.MatchDetail
{
    public class ServiceUnitTests
    {
        [Test]
        [Category("CompanyWinLossUnitTests")]
        public void Query_ReturnRightMatchDetailWinLoss()
        {
            // Arrange   
            var expectedMatchDetailWinLoss = CreateExpectedMatchDetailWinLoss();
            var calculationService = new CalculationServiceImp();
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
            var expectedLeagues = CreateExpectedLeagues();
            var expectedGrandTotal = CreateExpectedGrandTotal();

            return new WinLossModel
            {
                Leagues = expectedLeagues,
                Total = expectedGrandTotal
            };
        }

        private List<RawWinLoss> CreateFakeRawWinLoss()
        {
            return new List<RawWinLoss>
            {
                WinLossFactory.CreateRawWinLoss(0, "League 1", "Race 1", 100, 110, 10, 500, 600, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, "League 1", "Race 2", 110, 120, 11, 550, 660, 990, 1100),
                WinLossFactory.CreateRawWinLoss(0, "League 2", "Race 1", 100, 110, 10, 500, 600, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, "League 2", "Race 2", 110, 120, 11, 550, 660, 990, 1100)
            };
        }

        private List<LeagueWinLoss> CreateExpectedLeagues()
        {
            var league1 = CreateExpectedLeagueWinLoss("League 1");
            var league2 = CreateExpectedLeagueWinLoss("League 2");

            return new List<LeagueWinLoss> { league1, league2 };
        }

        private LeagueWinLoss CreateExpectedLeagueWinLoss(string leagueName)
        {
            var expectedRaces = new List<WinLoss>
            {
                WinLossFactory.CreateWinLoss(0, "Race 1", 100, 110, 10, 500, 600, -100, 900, 1000, 500m / 900, 600m / 1000),
                WinLossFactory.CreateWinLoss(0, "Race 2", 110, 120, 11, 550, 660, -110, 990, 1100, 550m / 990, 660m / 1100)
            };

            var expectedTotal = WinLossFactory.CreateWinLoss(0, "Total", 210, 230, 21, 1050, 1260, -210, 1980, 2100, 1050m / 1980, 1260m / 2100);

            return new LeagueWinLoss
            {
                LeagueName = leagueName,
                Races = expectedRaces,
                Total = expectedTotal
            };
        }

        private WinLoss CreateExpectedGrandTotal()
        {
            return WinLossFactory.CreateWinLoss(0, "Grand Total", 420, 460, 42, 2100, 2520, -420, 3780, 4200, 2100m / 3780, 2520m / 4200);
        }

        private bool AreTwoMatchDetailWinLossEqual(WinLossModel first, WinLossModel second)
        {
            if (first.Leagues.Count != second.Leagues.Count)
            {
                return false;
            }

            if (!WinLossComparision.AreTwoWinLossEqual(first.Total, second.Total))
            {
                return false;
            }

            return !first.Leagues.Where((t, i) => !AreTwoLeagueWinLossEqual(t, second.Leagues[i])).Any();
        }

        private bool AreTwoLeagueWinLossEqual(LeagueWinLoss first, LeagueWinLoss second)
        {
            return first.LeagueName == second.LeagueName
                && WinLossComparision.AreTwoWinLossListEqual(first.Races, second.Races);
        }
    }
}
