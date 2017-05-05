using MediatR;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Filter;
using FilterProduct = UniversalReports.PlayForFun.Filter.Product;

namespace UniversalReports.PlayForFun.UnitTests.Filter
{
    public class PlayForFunFilterControllerUnitTests
    {
        [Test]
        public async Task Product_Always_CallMediatorSend()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();

            // Act
            var controller = new PlayForFunFilterController(mediator);
            await controller.Product();

            // Assert
            await mediator.Received().Send(Arg.Any<FilterProduct.HttpParameterJson>());
        }
    }
}