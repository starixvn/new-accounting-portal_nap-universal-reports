using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.BetCount
{
    public class HandlerExcelUnitTests
    {
        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        {
            // Arrange
            var mapper = Substitute.For<IMapper>();
            var punterAnalysisService = Substitute.For<PunterAnalysisService>();
            var excelSetting = Substitute.For<IExcelSetting>();
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(mapper, punterAnalysisService, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

            // Assert
            await excelBuilder.Received().CreateExcelPackage(Arg.Any<ExcelViewModel>(), Arg.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var emptyExcelViewModel = new ExcelViewModel();
            var setting = new ExcelSetting
            {
                SheetName = "AnySheetName",
                StartRowIndex = 5,
                TemplatePath = "AnyTemplatePath",
                Title = "Any Title",
                TitleCellRange = "A1:E2",
                Filter = "Any Filter",
                FilterCellRange = "A3:E4"
            };

            var mapper = Substitute.For<IMapper>();
            mapper.Map<ExcelViewModel>(Arg.Any<ReportModelBase<BetCountModel>>()).Returns(emptyExcelViewModel);
            var punterAnalysisService = Substitute.For<PunterAnalysisService>();
            var excelSetting = Substitute.For<IExcelSetting>();
            excelSetting.CreateSetting(Arg.Any<ExcelSettingParams>()).Returns(setting);
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(mapper, punterAnalysisService, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

            // Assert
            await excelBuilder.Received().CreateExcelPackage(Arg.Is(emptyExcelViewModel), Arg.Is(setting));
        }
    }
}
