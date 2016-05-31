using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;
using UniversalReports.CompanyWinLoss.UnitTests.TestUtility;
using commonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_Should_Return_Right_MatchDetail()
        {
            // Arrange
            var fakeData = TestDataLoader.Load<List<RawWinLoss>>("data-1-fakeData");
            var expected = TestDataLoader.Load<WinLossModel>("data-1-expected");

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
