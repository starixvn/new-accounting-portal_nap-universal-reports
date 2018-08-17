using Fanex.RemotingRef;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Tests.Common.Services
{
    public class RemotingRef3RDServiceTests
    {
        [Test]
        public void GetTeamName_ReturnsNotNullString()
        {
            var remotingRefService = Substitute.For<IRemotingRefService>();
            var service = new RemotingRef3rdServiceImp(remotingRefService);

            var teamName = service.GetTeamName(1);

            Assert.That(teamName, Is.Not.Null);
        }

        [Test]
        public void GetLeagueName_ReturnsNotNullString()
        {
            var remotingRefService = Substitute.For<IRemotingRefService>();
            var service = new RemotingRef3rdServiceImp(remotingRefService);

            var leagueName = service.GetLeagueName(1);

            Assert.That(leagueName, Is.Not.Null);
        }
    }
}
