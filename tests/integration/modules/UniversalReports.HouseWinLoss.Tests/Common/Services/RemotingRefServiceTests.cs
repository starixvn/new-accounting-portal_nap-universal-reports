using NUnit.Framework;
using RemotingRef;
using UniversalReports.HouseWinLoss.Common.Services;

namespace UniversalReports.HouseWinLoss.Tests.Common.Services
{
    public class RemotingRefServiceTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            RefData.GetBetTypeName("1", string.Empty);
        }

        [Test]
        public void GetTeamName_ReturnsNotNullString()
        {
            var service = new RemotingRefServiceImp();

            var teamName = service.GetTeamName(5);

            Assert.That(teamName, Is.Not.Null);
        }

        [Test]
        public void GetLeagueName_ReturnsNotNullString()
        {
            var service = new RemotingRefServiceImp();

            var leagueName = service.GetLeagueName(3);

            Assert.That(leagueName, Is.Not.Null);
        }
    }
}