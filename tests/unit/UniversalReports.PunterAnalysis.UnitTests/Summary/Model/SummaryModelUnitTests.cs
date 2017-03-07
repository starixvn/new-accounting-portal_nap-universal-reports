using NUnit.Framework;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Summary.Model
{
    public class SummaryModelUnitTests
    {
        [Test]
        public void SummaryModel_CalculateMarginWithTurnoverIsZero_ReturnMarginZero()
        {
            // Arrange
            var model = new SummaryModel { Turnover = 0, WinLoss = 500 };
            var expected = 0;
            var result = model.Margin;

            // Assert
            Assert.That(result.Equals(expected));
        }

        [Test]
        public void SummaryModel_CalculateMarginWithTurnoverIsGreaterThanZero_ReturnMarginGreaterThanZero()
        {
            // Arrange
            var model = new SummaryModel { Turnover = 1000, WinLoss = 500 };
            var expected = 0.5m;
            var result = model.Margin;

            // Assert
            Assert.That(result.Equals(expected));
        }
    }
}
