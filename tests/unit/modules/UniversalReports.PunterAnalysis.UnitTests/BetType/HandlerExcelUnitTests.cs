using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
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
            var excelSetting = Substitute.For<ExcelSettingFactory>();
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(punterAnalysisService, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Any<SummaryEntity<BetTypeExcelModel>>(), Arg.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var setting = new ExcelSetting
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
            punterAnalysisService.Query<BetTypeModel>(Arg.Any<ICriteria>()).Returns(new SummaryEntity<BetTypeModel>());

            var excelSetting = Substitute.For<ExcelSettingFactory>();
            excelSetting.CreateSetting(Arg.Any<ExcelSettingParams>()).Returns(setting);
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(punterAnalysisService, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
                Arg.Is<SummaryEntity<BetTypeExcelModel>>(x => x.Entities.Count == 0 && x.Total == null),
                Arg.Is(setting));
        }
    }
}
