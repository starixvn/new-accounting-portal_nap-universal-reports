using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
using UniversalReports.Exchange.Filter.Licensee;

namespace UniversalReports.Exchange.UnitTests.Filter.Licensee
{
    [TestFixture]
    public class HandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightLicensee()
        {
            // Arrange
            var licensee = fixture.Create<IEnumerable<LicenseeModel>>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LicenseeModel>(Arg.Any<Criteria>()).Returns(licensee);

            var handler = new Handler(repository);

            // Act
            var model = await handler.Handle(new HttpParameterJson());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(licensee));
        }
    }
}
