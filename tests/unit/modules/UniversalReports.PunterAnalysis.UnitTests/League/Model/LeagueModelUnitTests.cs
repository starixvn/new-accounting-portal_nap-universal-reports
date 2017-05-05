using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.League.Model
{
    public class LeagueModelUnitTests
    {
        [Test]
        public void OperatorPlus_TwoLeagueModels_ReturnsCorrectSumValue()
        {
            // Arrange
            var firstObject = new LeagueModel
            {
                LeagueName = "League 1",
                PeriodGroups = new List<PeriodGroup>
                 {
                    new PeriodGroup
                    {
                        WinLoss = 300,
                        Turnover = 500,
                        BetCount = 5
                    }
                 }
            };

            var secondObject = new LeagueModel
            {
                LeagueName = "League 2",
                PeriodGroups = new List<PeriodGroup>
                {
                    new PeriodGroup
                    {
                        WinLoss = 150,
                        Turnover = 250,
                        BetCount = 3
                    }
                 }
            };

            var expectedObject = new LeagueModel
            {
                LeagueName = string.Empty,
                PeriodGroups = new List<PeriodGroup>
                {
                    new PeriodGroup
                    {
                        WinLoss = 450,
                        Turnover = 750,
                        BetCount = 8
                    }
                 }
            };

            // Act
            var sumObject = firstObject + secondObject;

            // Assert
            Assert.That(sumObject, IsDeeplyEqual.To(expectedObject));
        }
    }
}
