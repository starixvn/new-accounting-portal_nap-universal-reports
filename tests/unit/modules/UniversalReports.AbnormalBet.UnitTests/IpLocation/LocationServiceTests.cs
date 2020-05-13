using AutoFixture;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.IpLocation;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.UnitTests.IpLocation
{
    [TestFixture]
    [Category("AbnormalBet")]
    public class LocationServiceTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task QueryIP_WithSubstituteRepository_ReturnRightLocation()
        {
            // Arrange
            var location = fixture.Create<LocationModel>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<LocationModel>(Arg.Compat.Any<GetIPInfoCriteria>()).Returns(location);

            var service = new LocationServiceImp(repository);

            // Act
            var model = await service.QueryIP("127.0.0.1");

            // Assert
            Assert.That(model, IsDeeplyEqual.To(location));
        }
    }
}
