using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.Soccer.GroupBetType;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using BaseCalculationServiceImp = UniversalReports.HouseWinLoss.Soccer.BaseService.BaseCalculationServiceImp;

namespace UniversalReports.HouseWinLoss.UnitTests.Soccer.GroupBetType
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightResult()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("Soccer.GroupBetType.Service.data-1-fakeData");
            var expected = TestDataLoader.Load<GroupBetTypeWinLossModel>("Soccer.GroupBetType.Service.data-1-expected");

            var refService = Substitute.For<RemotingRefService>();
            var calculatorService = new BaseCalculationServiceImp(refService);
            refService.GetMatchCode(Arg.Compat.Any<string>()).Returns("Any Name");
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Compat.Any<WinLossCriteria>()).Returns(fakeData);

            // Act
            var service = new GroupBetTypeWinLossServiceImp(rawWinLossService, calculatorService);
            var result = service.Query(new TestCriteria());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}