using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
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
            //// Arrange
            //var exchangeModel = fixture.Create<SummaryEntity<ExchangeEntity>>();

            //var service = Substitute.For<Service>();
            //service.Query(Arg.Compat.Any<HttpParameterJson>()).Returns(exchangeModel);

            //var handler = new Handler(service);

            //// Act
            //var model = await handler.Handle(new HttpParameterJson(), new CancellationToken());

            //// Assert
            //Assert.That(model, IsDeeplyEqual.To(exchangeModel));
        }
    }
}
