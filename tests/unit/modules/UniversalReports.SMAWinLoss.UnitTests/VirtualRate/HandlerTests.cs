using AutoFixture;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.VirtualRate;

namespace UniversalReports.SMAWinLoss.UnitTests.VirtualRate
{
    [TestFixture]
    [Category("SMAWinLoss")]
    public class HandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightVirtualRate()
        {
            // Arrange
            var rates = fixture.Create<IEnumerable<VirtualRateModel>>();

            var service = Substitute.For<VirtualRateService>();
            service.GetVirtualRate(Arg.Compat.Any<VirtualRateHttpParameter>()).Returns(rates);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new VirtualRateHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(rates));
        }
    }
}