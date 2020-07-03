using AutoFixture;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Main;

namespace UniversalReports.SBPerformance.UnitTests.Main
{
    [TestFixture]
    [Category("SBPerformance")]
    public class MainHandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSummaryEntity()
        {
            // Arrange
            var fakeModel = fixture.Create<SummaryEntity<ItemModel>>();

            var service = Substitute.For<MainService>();
            service.Query(Arg.Compat.Any<HttpParameter>()).Returns(fakeModel);

            var handler = new MainHandler(service);

            // Act
            var model = await handler.Handle(new HttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(fakeModel));
        }
    }
}