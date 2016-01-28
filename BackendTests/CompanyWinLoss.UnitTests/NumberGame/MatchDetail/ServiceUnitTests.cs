using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
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
        public void Query_ReturnRightNumberGameMatchDetailWinLoss()
        {
            // Arrange   
            var expectedMatchDetailWinLoss = CreateExpectedNumberGameMatchDetailWinLoss();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            var fakeData = CreateFakeRawWinLoss();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = AreTwoNumberGameMatchDetailWinLossEqual(expectedMatchDetailWinLoss, result);
            Assert.True(equal);
        }

        private WinLossModel CreateExpectedNumberGameMatchDetailWinLoss()
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
                WinLossFactory.CreateRawWinLoss(0, "League 1", "MatchCode 1", false, 100, 110, 10, 500, 600, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, "League 1", "MatchCode 2", false, 110, 120, 11, 550, 660, 990, 1100),
                WinLossFactory.CreateRawWinLoss(0, "League 2", "MatchCode 1", false, 100, 110, 10, 500, 600, 900, 1000),
                WinLossFactory.CreateRawWinLoss(0, "League 2", "MatchCode 2", false, 110, 120, 11, 550, 660, 990, 1100)
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
                WinLossFactory.CreateWinLoss(0, "MatchCode 1", 100, 110, 10, 500, 600, -100, 900, 1000, 5m / 9, 0.6m),
                WinLossFactory.CreateWinLoss(0, "MatchCode 2", 110, 120, 11, 550, 660, -110, 990, 1100, 5m / 9, 0.6m)
            };

            return new LeagueWinLoss
            {
                LeagueName = leagueName,
                Matches = expectedMatches
            };
        }

        private WinLoss CreateExpectedGrandTotal()
        {
            return WinLossFactory.CreateWinLoss(0, string.Empty, 420, 460, 42, 2100, 2520, -420, 3780, 4200, 5m / 9, 0.6m);
        }


        private bool AreTwoNumberGameMatchDetailWinLossEqual(WinLossModel first, WinLossModel second)
        {
            if (first.Leagues.Count != second.Leagues.Count)
            {
                return false;
            }

            if (!WinLossComparision.AreTwoWinLossEqual(first.Total, second.Total))
            {
                return false;
            }

            return !first.Leagues.Where((t, i) => !AreTwoNumberGameLeagueWinLossEqual(t, second.Leagues[i])).Any();
        }

        private bool AreTwoNumberGameLeagueWinLossEqual(LeagueWinLoss first, LeagueWinLoss second)
        {
            return first.LeagueName == second.LeagueName
                && WinLossComparision.AreTwoWinLossListEqual(first.Matches, second.Matches);
        }
    }
}
