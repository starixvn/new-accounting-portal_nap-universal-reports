using System.Threading.Tasks;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
using UniversalReports.ActualMemberBet.Common;
using UniversalReports.ActualMemberBet.Product;

namespace UniversalReports.ActualMemberBet.UnitTests.Product
{
    [TestFixture]
    public class HandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSummaryEntity()
        {
            // Arrange
            var fakeModel = fixture.Create<SummaryEntity<ProductActualMemberBet>>();

            var service = Substitute.For<ActualMemberBetService>();
            service.Query<ProductActualMemberBet>(Arg.Any<Criteria>()).Returns(fakeModel);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new HttpParameter());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(fakeModel));
        }
    }
}
