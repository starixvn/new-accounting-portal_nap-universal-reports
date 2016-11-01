using System;
using NUnit.Framework;
using UniversalReports.Core.Factory;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using UniversalReports.HouseWinLoss.VirtualSports.BetType;

namespace UniversalReports.HouseWinLoss.UnitTests.Factory
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class CriteriaFactoryUnitTests
    {
        [Test]
        public void Transform_VirtualSportsBetTypeQueryModel_ReturnRightCriteria()
        {
            // Arrange
            var expectedCriteria = new Criteria
            {
                StartDate = CreateDateTime(1),
                EndDate = CreateDateTime(20),
                SportType = 10
            };

            var model = new QueryModel
            {
                StartDate = CreateDateTime(1),
                EndDate = CreateDateTime(20),
                SportType = 10
            };

            // Act
            var criteria = CriteriaFactory.Transform<Criteria>(model);

            // Assert
            ComparisonAssert.AreEqual(expectedCriteria, criteria);
        }

        private DateTime CreateDateTime(int day)
        {
            return new DateTime(2010, 1, day);
        }
    }
}