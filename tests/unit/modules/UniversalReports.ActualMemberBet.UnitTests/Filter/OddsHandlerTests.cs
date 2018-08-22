using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
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
            var model = await handler.Handle(new OddsHttpParameter(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(odds));
        }
    }
}
