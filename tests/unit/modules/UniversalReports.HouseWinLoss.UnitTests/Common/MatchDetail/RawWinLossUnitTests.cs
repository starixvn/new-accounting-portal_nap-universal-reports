using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using UniversalReports.HouseWinLoss.Common.MatchDetail;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.MatchDetail
{
    public class RawWinLossUnitTests
    {
        [Test]
        [SuppressMessage("StyleCop.CSharp.StylecopPlus.Rules",
            "SP2101:MethodMustNotContainMoreLinesThan",
            Justification = "Reviewed. Suppression is OK here.")]
        public void Add_ShouldReturnRightSumValue()
        {
            // Arrange
            var firstWinLoss = new RawWinLoss
            {
                MatchId = 1,
                MatchCode = string.Empty,
                EventDate = DateTime.Today,
                SportType = 0,
                IsNeutral = false,
                HomeId = 1,
                AwayId = 1,
                HomeName = string.Empty,
                AwayName = string.Empty,
                LeagueId = 1,
                MemberWinLoss = 100m,
                SMAWinLoss = 100m,
                Commission = 10m,
                RealIncome = 200m,
                VirtualIncome = 200m,
                VarianceIncome = 0m,
                RealTurnover = 400m,
                VirtualTurnover = 400m
            };

            var secondWinLoss = new RawWinLoss
            {
                MatchId = 2,
                MatchCode = string.Empty,
                EventDate = DateTime.Today,
                SportType = 0,
                IsNeutral = false,
                HomeId = 2,
                AwayId = 2,
                HomeName = string.Empty,
                AwayName = string.Empty,
                LeagueId = 1,
                MemberWinLoss = 200m,
                SMAWinLoss = 200m,
                Commission = 20m,
                RealIncome = 400m,
                VirtualIncome = 400m,
                VarianceIncome = 0m,
                RealTurnover = 800m,
                VirtualTurnover = 800m
            };

            var expectedWinLoss = new RawWinLoss
            {
                MatchId = 0,
                MatchCode = string.Empty,
                EventDate = DateTime.MinValue,
                SportType = 0,
                IsNeutral = false,
                HomeId = 0,
                AwayId = 0,
                HomeName = string.Empty,
                AwayName = string.Empty,
                LeagueId = 0,
                MemberWinLoss = 300m,
                SMAWinLoss = 300m,
                Commission = 30m,
                RealIncome = 600m,
                VirtualIncome = 600m,
                VarianceIncome = 0m,
                RealTurnover = 1200m,
                VirtualTurnover = 1200m
            };

            // Assert
            var sumWinLoss = firstWinLoss + secondWinLoss;
            Assert.That(sumWinLoss, IsDeeplyEqual.To(expectedWinLoss));
        }
    }
}
