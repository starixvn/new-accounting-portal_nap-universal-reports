using AutoFixture;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Model;
using UniversalReports.AbnormalBet.Report;

namespace UniversalReports.AbnormalBet.UnitTests.Report
{
    [TestFixture]
    [Category("AbnormalBet")]
    public class ReportHandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightMember()
        {
            // Arrange
            var members = fixture.Create<MemberModel>();

            var service = Substitute.For<ReportService>();
            service.QueryMember(Arg.Compat.Any<MemberQueryCriteria>()).Returns(members);

            var handler = new ReportHandler(service);

            // Act
            var model = await handler.Handle(new MemberHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(members));
        }

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightLicensee()
        {
            // Arrange
            var licensees = fixture.Create<LicenseeModel>();

            var service = Substitute.For<ReportService>();
            service.QueryLicensee(Arg.Compat.Any<LicenseeQueryCriteria>()).Returns(licensees);

            var handler = new ReportHandler(service);

            // Act
            var model = await handler.Handle(new LicenseeHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(licensees));
        }
    }
}