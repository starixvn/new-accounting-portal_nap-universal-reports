using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.BetCount
{
    public class HandlerExcelUnitTests
    {
        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        {
            // Arrange
            var betCountService = Substitute.For<BetCountService>();
            var excelSettingFactory = Substitute.For<ExcelSettingFactory>();
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(betCountService, excelSettingFactory, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Any<SummaryEntity<BetCountExcelModel>>(), Arg.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var excelSetting = new ExcelSetting
            {
                SheetName = "AnySheetName",
                StartRowIndex = 5,
                TemplatePath = "AnyTemplatePath",
                Title = "Any Title",
                TitleCellRange = "A1:E2",
                Filter = "Any Filter",
                FilterCellRange = "A3:E4"
            };

            var betCountService = Substitute.For<BetCountService>();
            betCountService.Query(Arg.Any<Criteria>()).Returns(new SummaryEntity<BetCountModel>());

            var excelSettingFactory = Substitute.For<ExcelSettingFactory>();
            excelSettingFactory.CreateSetting(Arg.Any<ExcelSettingParams>()).Returns(excelSetting);

            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(betCountService, excelSettingFactory, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
                Arg.Is<SummaryEntity<BetCountExcelModel>>(x => x.Entities.Count == 0 && x.Total == null),
                Arg.Is(excelSetting));
        }
    }
}