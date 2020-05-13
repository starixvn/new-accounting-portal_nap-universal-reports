using AutoFixture;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.IpLocation;
using UniversalReports.AbnormalBet.Model;
using UniversalReports.AbnormalBet.Report;

namespace UniversalReports.AbnormalBet.UnitTests.Report
{
    [TestFixture]
    [Category("AbnormalBet")]
    public class ReportServiceTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task QueryLicensee_WithSubstituteRepository_ReturnRightLicensee()
        {
            // Arrange
            var licensees = fixture.Create<IEnumerable<LicenseeModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LicenseeModel>(Arg.Compat.Any<LicenseeQueryCriteria>()).Returns(licensees);

            var locationService = Substitute.For<LocationService>();
            locationService.QueryIP(Arg.Compat.Any<string>()).Returns(new LocationModel
            {
                CountryLong = "Viet Nam",
                IpCity = string.Empty,
                IpRegion = string.Empty
            });

            var service = new ReportServiceImp(repository, locationService);

            // Act
            var model = await service.QueryLicensee(new LicenseeQueryCriteria());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(licensees));
        }

        [Test]
        public async Task QueryMember_WithSubstituteRepository_ReturnRightMember()
        {
            // Arrange
            var members = fixture.Create<IEnumerable<MemberModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<MemberModel>(Arg.Compat.Any<MemberQueryCriteria>()).Returns(members);

            var locationService = Substitute.For<LocationService>();
            locationService.QueryIP(Arg.Compat.Any<string>()).Returns(new LocationModel
            {
                CountryLong = "Viet Nam",
                IpCity = string.Empty,
                IpRegion = string.Empty
            });

            var service = new ReportServiceImp(repository, locationService);


            // Act
            var model = await service.QueryMember(new MemberQueryCriteria());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(members));
        }
    }
}
