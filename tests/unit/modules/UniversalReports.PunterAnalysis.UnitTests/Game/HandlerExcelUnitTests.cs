using System.Threading;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Game;
using UniversalReports.PunterAnalysis.Game.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.Game
{
    public class HandlerExcelUnitTests
    {
        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        {
            // Arrange
            var punterAnalysisService = Substitute.For<PunterAnalysisService>();
            var excelSettingFactory = Substitute.For<ExcelSettingFactory>();
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(punterAnalysisService, excelSettingFactory, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Compat.Any<SummaryEntity<GameExcelModel>>(), Arg.Compat.Any<ExcelSetting>());
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
                FilterCellRange = "A3:E5"
            };

            var punterAnalysisService = Substitute.For<PunterAnalysisService>();
            punterAnalysisService.Query<GameModel>(Arg.Compat.Any<ICriteria>()).Returns(new SummaryEntity<GameModel>());

            var excelSettingFactory = Substitute.For<ExcelSettingFactory>();
            excelSettingFactory.CreateSetting(Arg.Compat.Any<ExcelSettingParams>()).Returns(excelSetting);

            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(punterAnalysisService, excelSettingFactory, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
             Arg.Compat.Is<SummaryEntity<GameExcelModel>>(x => x.Entities.Count == 0 && x.Total == null),
             Arg.Compat.Is(excelSetting));
        }
    }
}