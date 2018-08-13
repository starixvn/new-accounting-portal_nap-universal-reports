using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
using UniversalReports.ActualMemberBet.Filter;

namespace UniversalReports.ActualMemberBet.UnitTests.Filter
{
    [TestFixture]
    public class OddsHandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightOdds()
        {
            // Arrange
            var odds = fixture.Create<IEnumerable<Odds>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Odds>(Arg.Any<OddsCriteria>()).Returns(odds);

            var handler = new OddsHandler(repository);

            // Act
            var model = await handler.Handle(new OddsHttpParameter());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(odds));
        }
    }
}
