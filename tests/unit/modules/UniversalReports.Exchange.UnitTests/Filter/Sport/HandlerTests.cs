using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.Exchange.Filter.Sport;

namespace UniversalReports.Exchange.UnitTests.Filter.Sport
{
    [TestFixture]
    public class HandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSport()
        {
            // Arrange
            var sport = fixture.Create<IEnumerable<SportModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SportModel>(Arg.Compat.Any<Criteria>()).Returns(sport);

            var handler = new Handler(repository);

            // Act
            var model = await handler.Handle(new HttpParameterJson(), new CancellationToken());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sport));
        }
    }
}
