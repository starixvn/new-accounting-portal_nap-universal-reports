using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.AssociatedAccount
{
    public class PunterAnalysisAssociatedAccountControllerUnitTests
    {
        [Test]
        public async Task Index_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterJson = new HttpParameterJson();

            // Act
            var controller = new PunterAnalysisAssociatedAccountController(mediator);
            await controller.Index(httpParameterJson);

            // Assert
            await mediator.Received().Send(Arg.Any<HttpParameterJson>());
        }
    }
}