using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.MatchDetail;
using UniversalReports.HouseWinLoss.UnitTests.TestUtility;
using commonServices = UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.UnitTests.Common.MatchDetail
{
    [TestFixture]
    [Category("HouseWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_Should_Return_Right_MatchDetail()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("Common.MatchDetail.Service-fakeData");
            var expected = TestDataLoader.Load<WinLossModel>("Common.MatchDetail.Service-expected");

            var rawService = Substitute.For<RawWinLossService>();
            rawService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeData);

            var refService = Substitute.For<commonServices.RemotingRefService>();
            refService.GetLeagueName(Arg.Any<int>()).Returns(string.Empty);
            refService.GetTeamName(Arg.Any<int>(), Arg.Any<string>()).Returns(string.Empty);
            var calculationService = new CalculationServiceImp(refService);

            // Act
            var service = new WinLossServiceImp(rawService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            ComparisonAssert.AreEqual(expected, result);
        }
    }
}