using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.ActualMemberBet.Product;

namespace UniversalReports.ActualMemberBet.UnitTests.Product
{
    [TestFixture]
    public class ActutalMemberBetProductControllerTests
    {
        [Test]
        public async Task Index_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameter = new HttpParameter();

            // Act
            var controller = new ActutalMemberBetProductController(mediator);
            await controller.Index(httpParameter);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<HttpParameter>());
        }

        [Test]
        public async Task Excel_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var httpParameterExcel = new HttpParameterExcel();

            // Act
            var controller = new ActutalMemberBetProductController(mediator);
            await controller.Excel(httpParameterExcel);

            // Assert
            await mediator.Received().Send(Arg.Compat.Any<HttpParameterExcel>());
        }
    }
}
