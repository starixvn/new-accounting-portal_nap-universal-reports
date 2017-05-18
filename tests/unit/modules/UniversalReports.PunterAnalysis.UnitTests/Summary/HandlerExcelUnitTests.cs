using AutoMapper;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.Summary
{
    public class HandlerExcelUnitTests
    {
        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        {
            // Arrange
            var mapper = Substitute.For<IMapper>();
            var punterAnalysisService = Substitute.For<PunterAnalysisService>();
            var excelSetting = Substitute.For<ExcelSettingFactory>();
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(mapper, punterAnalysisService, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Any<SummaryEntity<SummaryExcelModel>>(), Arg.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var emptyExcelViewModel = new SummaryEntity<SummaryExcelModel>();
            var settings = new ExcelSetting
            {
                SheetName = "AnySheetName",
                StartRowIndex = 8,
                TemplatePath = "AnyTemplatePath",
                Title = "Any Title",
                TitleCellRange = "A1:E2",
                Filter = "Any Filter",
                FilterCellRange = "A3:E5"
            };

            var mapper = Substitute.For<IMapper>();
            mapper.Map<SummaryEntity<SummaryExcelModel>>(Arg.Any<SummaryEntity<SummaryModel>>()).Returns(emptyExcelViewModel);
            var punterAnalysisService = Substitute.For<PunterAnalysisService>();
            var excelSetting = Substitute.For<ExcelSettingFactory>();
            excelSetting.CreateSetting(Arg.Any<ExcelSettingParams>()).Returns(settings);
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(mapper, punterAnalysisService, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Is(emptyExcelViewModel), Arg.Is(settings));
        }
    }
}
