using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
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
            repository.FetchAsync<SportModel>(Arg.Any<Criteria>()).Returns(sport);

            var handler = new Handler(repository);

            // Act
            var model = await handler.Handle(new HttpParameterJson());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(sport));
        }
    }
}
