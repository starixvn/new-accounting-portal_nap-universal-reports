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
    public class SiteHandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightSite()
        {
            // Arrange
            var currencies = fixture.Create<IEnumerable<Site>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Site>(Arg.Any<SiteCriteria>()).Returns(currencies);

            var handler = new SiteHandler(repository);

            // Act
            var model = await handler.Handle(new SiteHttpParameter());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(currencies));
        }
    }
}
