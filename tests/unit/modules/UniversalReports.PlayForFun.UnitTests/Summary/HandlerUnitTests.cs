using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.UnitTests.Summary
{
    public class HandlerUnitTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_Always_ReturnsReportModelFromService()
        {
            // Arrange
            var anyReportModel = fixture.Create<SummaryEntity<SummaryModel>>();

            var service = Substitute.For<PlayForFunService>();
            service.Query<SummaryModel>(Arg.Any<ICriteria>()).Returns(anyReportModel);

            // Act
            var handler = new Handler(service);
            var viewModel = await handler.Handle(new HttpParameterJson());

            // Assert
            Assert.That(viewModel, IsDeeplyEqual.To(anyReportModel));
        }
    }
}