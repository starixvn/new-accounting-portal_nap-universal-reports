using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.Products;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;

namespace UniversalReports.HouseWinLoss.UnitTests.Products
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightProductWinLoss()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("Products.Service.data-1-fakeData");
            var expected = TestDataLoader.Load<ProductWinLoss>("Products.Service.data-1-expected");

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
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("Products.Service.data-2-fakeData");
            var expected = TestDataLoader.Load<ProductGroupWinLoss>("Products.Service.data-2-expected");

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