using System.Threading;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.SportType;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.SportType
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
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Any<SummaryEntity<SportTypeExcelModel>>(), Arg.Any<ExcelSetting>());
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
            punterAnalysisService.Query<SportTypeModel>(Arg.Any<ICriteria>()).Returns(new SummaryEntity<SportTypeModel>());

            var excelSettingFactory = Substitute.For<ExcelSettingFactory>();
            excelSettingFactory.CreateSetting(Arg.Any<ExcelSettingParams>()).Returns(excelSetting);

            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(punterAnalysisService, excelSettingFactory, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
              Arg.Is<SummaryEntity<SportTypeExcelModel>>(x => x.Entities.Count == 0 && x.Total == null),
              Arg.Is(excelSetting));
        }
    }
}