using System.Threading.Tasks;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
using UniversalReports.Exchange.Report;

namespace UniversalReports.Exchange.UnitTests.Report
{
    [TestFixture]
    public class HandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSummaryEntity()
        {
            // Arrange
            var exchangeModel = fixture.Create<SummaryEntity<ExchangeEntity>>();

            var service = Substitute.For<Service>();
            service.Query(Arg.Any<HttpParameterJson>()).Returns(exchangeModel);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new HttpParameterJson());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(exchangeModel));
        }
    }
}
