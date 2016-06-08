using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;
using UniversalReports.CompanyWinLoss.Products;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Products
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightProductWinLoss()
        {
            // Arrange   
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-1-fakeData");
            var expected = TestDataLoader.Load<ProductWinLoss>("data-1-expected");

            var criteria = new WinLossCriteria();
            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(criteria).Returns(fakeData);

            // Act 
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.Query(criteria);

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }

        [Test]
        public void GetProductGroup_ReturnRightGetProductGroupWinLoss()
        {
            // Arrange   
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-2-fakeData");
            var expected = TestDataLoader.Load<ProductGroupWinLoss>("data-2-expected");

            var calculationService = new CalculationServiceImp();
            var rawWinLossService = Substitute.For<RawWinLossService>();

            // Act
            var service = new ServiceImp(rawWinLossService, calculationService);
            var result = service.GetProductGroup(fakeData, "Non-Sports Total");

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
