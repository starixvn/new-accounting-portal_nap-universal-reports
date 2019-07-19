using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.ActualMemberBet.Bettype;
using UniversalReports.ActualMemberBet.Common;

namespace UniversalReports.ActualMemberBet.UnitTests.Bettype
{
    [TestFixture]
    public class HandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSummaryEntity()
        {
            // Arrange
            var fakeModel = fixture.Create<SummaryEntity<BetTypeActualMemberBet>>();

            var service = Substitute.For<ActualMemberBetService>();
            service.Query<BetTypeActualMemberBet>(Arg.Compat.Any<Criteria>()).Returns(fakeModel);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new HttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(fakeModel));
        }
    }
}
