using System.Collections.Generic;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.BasicWinLoss;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.Common.Services;
using UniversalReports.HouseWinLoss.Soccer.LiveNonLive;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using BaseCalculationServiceImp = UniversalReports.HouseWinLoss.Soccer.BaseService.BaseCalculationServiceImp;

namespace UniversalReports.HouseWinLoss.UnitTests.Soccer.LiveNonLive
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_ReturnRightResult()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<WinLossRaw>>("Soccer.LiveNonLive.Service.data-1-fakeData");
            var expected = TestDataLoader.Load<IEnumerable<BasicWinLossModel>>("Soccer.LiveNonLive.Service.data-1-expected");

            // Act
            var refService = Substitute.For<RemotingRefService>();
            var calculatorService = new BaseCalculationServiceImp(refService);
            var rawWinLossService = Substitute.For<RawWinLossService>();
            rawWinLossService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            var service = new SoccerLiveNonLiveWinLossServiceImp(rawWinLossService, calculatorService);
            var result = service.Query(Arg.Any<WinLossCriteria>());
            
            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}