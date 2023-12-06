using System.Threading;
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
            await handleExcel.Handle(new HttpParameterExcel(), new CancellationToken());

            // Assert
            excelBuilder.Received().Build(Arg.Compat.Any<HttpParameterExcel>(), Arg.Compat.Any<SummaryEntity<ExchangeExcelEntity>>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            //// Arrange
            //var service = Substitute.For<Service>();
            //service.Query(Arg.Compat.Any<HttpParameterJson>()).Returns(new SummaryEntity<ExchangeEntity>());

            //var excelBuilder = Substitute.For<ExcelBuilder>();
            //var handleExcel = new HandlerExcel(service, excelBuilder);
            //var excelParams = new HttpParameterExcel();

            //// Act
            //await handleExcel.Handle(excelParams, new CancellationToken());

            //// Assert
            //excelBuilder.Received().Build(
            //    Arg.Compat.Is(excelParams),
            //    Arg.Compat.Is<SummaryEntity<ExchangeExcelEntity>>(x => x.Entities.Count == 0 && x.Total == null));
        }
    }
}
