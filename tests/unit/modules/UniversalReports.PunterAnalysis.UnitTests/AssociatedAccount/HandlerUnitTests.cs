using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.AssociatedAccount
{
    public class HandlerUnitTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_Always_ReturnsReportModelFromFacade()
        {
            // Arrange
            var anyReportModel = fixture.Create<SummaryEntity<AssociatedSummaryModel>>();
            var facade = Substitute.For<AssociatedFacade>();
            facade.Query(Arg.Compat.Any<HttpParameterJson>()).Returns(anyReportModel);

            // Act
            var handler = new Handler(facade);
            var viewModel = await handler.Handle(new HttpParameterJson(), new CancellationToken());

            // Assert
            Assert.That(viewModel, IsDeeplyEqual.To(anyReportModel));
        }
    }
}