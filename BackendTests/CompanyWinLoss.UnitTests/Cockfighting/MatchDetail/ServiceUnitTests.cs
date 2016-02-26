using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using commonServices = UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.UnitTests.Cockfighting.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class ServiceUnitTests
    {
        [Test]
        public void Query_Should_Return_Right_MatchDetail()
        {
            // Arrange
            var fakeWinLoss = WinLossFactory.CreateFakeRawWinLoss();
            var expectedMatchDetail = WinLossFactory.CreateExpectMatchDetail();
            var rawService = Substitute.For<RawWinLossService>();
            rawService.Query(Arg.Any<WinLossCriteria>()).Returns(fakeWinLoss);
            var refService = Substitute.For<commonServices.RemotingRefService>();
            refService.GetLeagueName(Arg.Any<int>()).Returns("Any Arena");
            var calculationService = new CalculationServiceImp(refService);

            // Act
            var service = new ServiceImp(rawService, calculationService);
            var result = service.Query(Arg.Any<WinLossCriteria>());

            // Assert
            var equal = WinLossComparison.CompareTwoMatchDetailIsEqual(result, expectedMatchDetail);
            Assert.True(equal);
        }
    }
}
