using NUnit.Framework;
using RemotingRef;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Tests.Common.Services
{
    public class RemotingRef3rdServiceTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            RefData.GetBetTypeName("1", string.Empty);
        }

        [Test]
        public void GetTeamName_ReturnsNotNullString()
        {
            var service = new RemotingRef3rdServiceImp();

            var teamName = service.Get3rdTeamName(1);

            Assert.That(teamName, Is.Not.Null);
        }

        [Test]
        public void GetLeagueName_ReturnsNotNullString()
        {
            var service = new RemotingRef3rdServiceImp();

            var leagueName = service.Get3rdLeagueName(1);

            Assert.That(leagueName, Is.Not.Null);
        }
    }
}
