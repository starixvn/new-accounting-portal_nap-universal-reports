using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail;
using commonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.Cockfighting.MatchDetail
{
    [TestFixture]
    public class CalculationServiceUnitTests
    {
        [Test]
        public void CalulationMargin_Shoud_Return_Zero_When_Turnover_Is_Zero()
        {
            // Arrange
            const int Zero = 0;
            const int AnyIncome = 100;
            var refService = Substitute.For<commonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(refService);

            // Act
            var result = calculationService.CalulationMargin(AnyIncome, Zero);

            // Assert
            Assert.AreEqual(Zero, result);
        }

        [Test]
        public void CalulationMargin_Shoud_Return_Right_Margin()
        {
            // Arrange
            const decimal ExpectedMargin = 0.5m;
            var remotingRefService = Substitute.For<commonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalulationMargin(1m, 2m);

            // Assert
            Assert.AreEqual(ExpectedMargin, result);
        }

        [Test]
        public void FromRawWinLoss_Should_Return_Right_WinLoss()
        {
            // Arrange
            var rawWinLoss = CreateFakeRawWinLoss();
            var expectedWinLoss = CreateExpectedWinLoss();
            var remotingRefService = Substitute.For<commonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.FromRawWinLoss(rawWinLoss);

            // Assert
            var equal = WinLossComparison.CompareTwoWinLossIsEqual(result, expectedWinLoss);
            Assert.True(equal);
        }

        [Test]
        public void CalculationSum_Should_Return_Right_RawWinLoss_Total()
        {
            // Arrange
            var rawWinLoss = WinLossFactory.CreateFakeRawWinLoss();
            var expectedWinLossTotal = CreateExpectRawWinLossTotal();
            var remotingRefService = Substitute.For<commonServices.RemotingRefService>();
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculationSum(rawWinLoss);

            // Assert
            var equal = WinLossComparison.CompareTwoRawWinLossIsEqual(result, expectedWinLossTotal);
            Assert.True(equal);
        }

        [Test]
        public void CalculationArena_Should_Return_Right_Arena()
        {
            // Arrange
            const int AnyArenaId = 1;
            var fakeArena = CreateFakeArena();
            var expectedArena = CreateExpectedArenaWinLoss();
            var remotingRefService = Substitute.For<commonServices.RemotingRefService>();
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns("Any Arena");
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.CalculationArena(fakeArena, AnyArenaId);

            // Assert
            var equal = WinLossComparison.CompareTwoArenaIsEqual(result, expectedArena);
            Assert.True(equal);

        }

        [Test]
        public void Arenas_Should_Return_Right_List_Arena()
        {
            // Arrange
            var fakeRawWinLoss = WinLossFactory.CreateFakeRawWinLoss();
            var expectedArenas = WinLossFactory.CreateExpectedArenaWinLoss();
            var remotingRefService = Substitute.For<commonServices.RemotingRefService>();
            remotingRefService.GetLeagueName(Arg.Any<int>()).Returns("Any Arena");
            var calculationService = new CalculationServiceImp(remotingRefService);

            // Act
            var result = calculationService.Arenas(fakeRawWinLoss).ToList();

            // Assert
            var equal = WinLossComparison.CompareTwoListArenaIsEqual(result, expectedArenas);
            Assert.True(equal);
        }

        private RawWinLoss CreateFakeRawWinLoss()
        {
            return WinLossFactory.CreateRawWinLoss("match1", 1, "Home", "Away", 100, 120, 10, 10, 50);
        }

        private WinLoss CreateExpectedWinLoss()
        {
            return WinLossFactory.CreateWinLoss("match1", 1, "Home", "Away", 100, 120, 10, 10, 50, 0.2m);
        }

        private RawWinLoss CreateExpectRawWinLossTotal()
        {
            return WinLossFactory.CreateRawWinLoss(string.Empty, 0, string.Empty, string.Empty, 570, 720, 100, 600, 1200);
        }

        private List<RawWinLoss> CreateFakeArena()
        {
            var match1 = WinLossFactory.CreateRawWinLoss("match1", 1, "home1", "away1", 100, 120, 10, 200, 400);
            var match2 = WinLossFactory.CreateRawWinLoss("match2", 1, "home2", "away2", 120, 150, 20, 100, 200);

            return new List<RawWinLoss> { match1, match2 };
        }

        private ArenaWinLoss CreateExpectedArenaWinLoss()
        {
            var matches = WinLossFactory.CreateExpectedFirstArenaMatches();
            var total = WinLossFactory.CreateExpectedFirstArenaTotal();

            return new ArenaWinLoss
                {
                ArenaName = "Any Arena",
                Matches = matches,
                Total = total
            }; 
        }
    }
}
