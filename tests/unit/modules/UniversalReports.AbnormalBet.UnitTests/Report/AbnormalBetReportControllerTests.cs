using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Report;

namespace UniversalReports.AbnormalBet.UnitTests.Report
{
    [TestFixture]
    [Category("AbnormalBet")]
    public class AbnormalBetReportControllerTests
    {
        [Test]
        public async Task Member_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new AbnormalBetReportController(mediator);
            await controller.Member(new MemberHttpParameter());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<MemberHttpParameter>());
        }

        [Test]
        public async Task Licensee_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new AbnormalBetReportController(mediator);
            await controller.Licensee(new LicenseeHttpParameter());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<LicenseeHttpParameter>());
        }

        [Test]
        public async Task MemberExcel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new AbnormalBetReportController(mediator);
            await controller.MemberExcel(new MemberHttpParameterExcel());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<MemberHttpParameterExcel>());
        }

        [Test]
        public async Task LicenseeExcel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new AbnormalBetReportController(mediator);
            await controller.LicenseeExcel(new LicenseeHttpParameterExcel());

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<LicenseeHttpParameterExcel>());
        }
    }
}
