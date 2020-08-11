using AutoFixture;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.Summary;

namespace UniversalReports.SMAWinLoss.UnitTests.Summary
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
            var winlossModel = fixture.Create<WinLossModel>();

            var service = Substitute.For<WinLossService>();
            service.GetSMAWinLoss(Arg.Compat.Any<WinLossHttpParameter>()).Returns(winlossModel);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new WinLossHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(winlossModel));
        }
    }
}