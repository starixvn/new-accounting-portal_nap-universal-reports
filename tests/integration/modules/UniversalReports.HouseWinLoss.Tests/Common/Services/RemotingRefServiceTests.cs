using Fanex.RemotingRef;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Tests.Common.Services
{
    public class RemotingRefServiceTests
    {
        [Test]
        public void GetTeamName_ReturnsNotNullString()
        {
            var remotingRefService = Substitute.For<IRemotingRefService>();
            var service = new RemotingRefServiceImp(remotingRefService);

            var teamName = service.GetTeamName(5);

            Assert.That(teamName, Is.Not.Null);
        }

        [Test]
        public void GetLeagueName_ReturnsNotNullString()
        {
            var remotingRefService = Substitute.For<IRemotingRefService>();
            var service = new RemotingRefServiceImp(remotingRefService);

            var leagueName = service.GetLeagueName(3);

            Assert.That(leagueName, Is.Not.Null);
        }

        [Test]
        [TestCase("")]
        [TestCase("ABC")]
        public void GetMatchCode_Always_ReturnsNotNullString(string matchCode)
        {
            var remotingRefService = Substitute.For<IRemotingRefService>();
            var service = new RemotingRefServiceImp(remotingRefService);

            var refMatchCode = service.GetMatchCode(matchCode);

            Assert.That(refMatchCode, Is.Not.Null);
        }
    }
}