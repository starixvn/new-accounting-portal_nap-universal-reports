using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.NumberGame.MatchDetail;
using UniversalReports.CompanyWinLoss.UnitTests.Utility;

namespace UniversalReports.CompanyWinLoss.UnitTests.NumberGame.MatchDetail
{
    public class ServiceUnitTests
    {
        [Test]
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
                WinLossFactory.CreateRawWinLoss(0, "League 1", "MatchCode 1", 100, 110, 10, 500, 600, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, "League 1", "MatchCode 2", 110, 120, 11, 550, 660, 990, 1100),
                WinLossFactory.CreateRawWinLoss(0, "League 2", "MatchCode 1", 100, 110, 10, 500, 600, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, "League 2", "MatchCode 2", 110, 120, 11, 550, 660, 990, 1100)
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
            var expectedMatches = new List<WinLoss>
            {
                WinLossFactory.CreateWinLoss(0, "MatchCode 1", 100, 110, 10, 500, 600, -100, 900, 1000, 500m / 900, 600m / 1000),
                WinLossFactory.CreateWinLoss(0, "MatchCode 2", 110, 120, 11, 550, 660, -110, 990, 1100, 550m / 990, 660m / 1100)
            };

            return new LeagueWinLoss
            {
                LeagueName = leagueName,
                Matches = expectedMatches
            };
        }

        private WinLoss CreateExpectedGrandTotal()
        {
            return WinLossFactory.CreateWinLoss(0, string.Empty, 420, 460, 42, 2100, 2520, -420, 3780, 4200, 2100m / 3780, 2520m / 4200);
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
                && WinLossComparision.AreTwoWinLossListEqual(first.Matches, second.Matches);
        }
    }
}
