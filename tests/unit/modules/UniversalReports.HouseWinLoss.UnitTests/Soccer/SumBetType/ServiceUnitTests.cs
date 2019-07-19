using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.Soccer.SumBetType;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using BaseCalculationServiceImp = UniversalReports.HouseWinLoss.Soccer.BaseService.BaseCalculationServiceImp;

namespace UniversalReports.HouseWinLoss.UnitTests.Soccer.SumBetType
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightResult()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("Soccer.SumBetType.Service.data-1-fakeData");
            var expected = TestDataLoader.Load<SumBetTypeWinLossModel>("Soccer.SumBetType.Service.data-1-expected");

            // Act
            var refService = Substitute.For<RemotingRefService>();
            refService.GetMatchCode(Arg.Compat.Any<string>()).Returns("Any Name");
            var calculatorService = new BaseCalculationServiceImp(refService);
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Compat.Any<WinLossCriteria>()).Returns(fakeData);

            var service = new SumBetTypeWinLossServiceImp(rawWinLossService, calculatorService);
            var result = service.Query(new TestCriteria());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}