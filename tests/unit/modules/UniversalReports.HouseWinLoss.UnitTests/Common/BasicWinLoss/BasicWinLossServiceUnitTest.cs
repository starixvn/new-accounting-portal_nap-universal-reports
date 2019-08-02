using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.BasicWinLoss
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class BasicWinLossServiceUnitTest
    {
        [Test]
        public void Query_ReturnRightBasicWinLossSummary()
        {
            // Arrange
            var expected = TestDataLoader.Load<BasicWinLossModel>("Common.BasicWinLoss.BasicWinLossService.data-1-expected");
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("Common.BasicWinLoss.BasicWinLossService.data-1-fakeData");

            var refService = Substitute.For<RemotingRefService>();
            refService.GetMatchCode(Arg.Compat.Any<string>()).Returns("Any Name");
            var calculationService = new CalculationServiceImp(refService);
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Compat.Any<WinLossCriteria>()).Returns(fakeData);

            // Act
            var service = new BasicWinLossServiceImp(rawWinLossService, calculationService);
            var result = service.Query(new TestCriteria());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}