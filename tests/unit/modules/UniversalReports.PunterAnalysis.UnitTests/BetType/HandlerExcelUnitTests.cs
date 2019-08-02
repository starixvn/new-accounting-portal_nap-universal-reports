using System.Threading;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.BetType;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.BetType
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
            excelBuilder.Received().CreateExcelPackage(Arg.Compat.Any<SummaryEntity<BetTypeExcelModel>>(), Arg.Compat.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var excelSetting = new ExcelSetting
            {
                SheetName = "AnySheetName",
                StartRowIndex = 9,
                TemplatePath = "AnyTemplatePath",
                Title = "Any Title",
                TitleCellRange = "A1:M2",
                Filter = "Any Filter",
                FilterCellRange = "A3:M5"
            };

            var punterAnalysisService = Substitute.For<PunterAnalysisService>();
            punterAnalysisService.Query<BetTypeModel>(Arg.Compat.Any<ICriteria>()).Returns(new SummaryEntity<BetTypeModel>());

            var excelSettingFactory = Substitute.For<ExcelSettingFactory>();
            excelSettingFactory.CreateSetting(Arg.Compat.Any<ExcelSettingParams>()).Returns(excelSetting);
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(punterAnalysisService, excelSettingFactory, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
               Arg.Compat.Is<SummaryEntity<BetTypeExcelModel>>(x => x.Entities.Count == 0 && x.Total == null),
               Arg.Compat.Is(excelSetting));
        }
    }
}