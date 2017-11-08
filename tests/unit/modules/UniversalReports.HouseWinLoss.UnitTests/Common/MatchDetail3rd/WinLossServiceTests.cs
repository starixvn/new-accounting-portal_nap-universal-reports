using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.MatchDetail3rd;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using commonServices = UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.MatchDetail3rd
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class WinLossServiceTests
    {
        [Test]
        public void Query_Should_Return_Right_MatchDetail()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("Common.MatchDetail3rd.WinLossService-fakeData");
            var expected = TestDataLoader.Load<WinLossModel>("Common.MatchDetail3rd.WinLossService-expected");

            var rawService = Substitute.For<RawWinLossService>();
            rawService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            var refService = Substitute.For<commonServices.RemotingRef3rdService>();
            refService.Get3rdTeamName(Arg.Any<int>()).Returns(string.Empty);
            var calculationService = new CalculationServiceImp(refService);

            // Act
            var service = new WinLossServiceImp(rawService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}
