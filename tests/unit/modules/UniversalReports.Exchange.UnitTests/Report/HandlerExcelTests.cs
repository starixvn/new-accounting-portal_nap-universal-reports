using System.Threading.Tasks;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.Exchange.Report;

namespace UniversalReports.Exchange.UnitTests.Report
{
    [TestFixture]
    public class HandlerExcelTests
    {
        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        {
            // Arrange
            var service = Substitute.For<Service>();
            var excelBuilder = Substitute.For<ExcelBuilder>();
            var handleExcel = new HandlerExcel(service, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

            // Assert
            excelBuilder.Received().Build(Arg.Any<HttpParameterExcel>(), Arg.Any<SummaryEntity<ExchangeExcelEntity>>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var service = Substitute.For<Service>();
            service.Query(Arg.Any<HttpParameterJson>()).Returns(new SummaryEntity<ExchangeEntity>());

            var excelBuilder = Substitute.For<ExcelBuilder>();
            var handleExcel = new HandlerExcel(service, excelBuilder);
            var excelParams = new HttpParameterExcel();

            // Act
            await handleExcel.Handle(excelParams);

            // Assert
            excelBuilder.Received().Build(
                Arg.Is(excelParams),
                Arg.Is<SummaryEntity<ExchangeExcelEntity>>(x => x.Entities.Count == 0 && x.Total == null));
        }
    }
}
