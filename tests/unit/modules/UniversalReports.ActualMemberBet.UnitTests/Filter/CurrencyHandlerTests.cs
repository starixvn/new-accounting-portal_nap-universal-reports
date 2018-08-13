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
    public class CurrencyHandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightCurrency()
        {
            // Arrange
            var currencies = fixture.Create<IEnumerable<Currency>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Currency>(Arg.Any<CurrencyCriteria>()).Returns(currencies);

            var handler = new CurrencyHandler(repository);

            // Act
            var model = await handler.Handle(new CurrencyHttpParameter());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(currencies));
        }
    }
}
