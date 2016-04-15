using System;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Factory;
using UniversalReports.CompanyWinLoss.VirtualSports.BetType;

namespace UniversalReports.CompanyWinLoss.UnitTests.Factory
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
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
            Assert.True(AreCriteriaEqual(expectedCriteria, criteria));
        }

        private DateTime CreateDateTime(int day)
        {
            return new DateTime(2010, 1, day);
        }

        private bool AreCriteriaEqual(Criteria expected, Criteria model)
        {
            return expected.StartDate == model.StartDate
                && expected.EndDate == model.EndDate
                && expected.SportType == model.SportType;
        }
    }
}
