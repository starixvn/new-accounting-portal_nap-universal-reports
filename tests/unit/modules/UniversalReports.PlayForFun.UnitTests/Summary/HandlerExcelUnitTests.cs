using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Detail.Model;
using UniversalReports.PlayForFun.Summary;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.UnitTests.Summary
{
    public class HandlerExcelUnitTests
    {
        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        {
            // Arrange
            var mapper = Substitute.For<IMapper>();

            var punterAnalysisService = Substitute.For<PlayForFunService>();

            var configurationService = Substitute.For<ApplicationConfigurationService>();
            configurationService.CurrentDirectory.Returns("D:");

            var excelBuilder = Substitute.For<PlayForFunExcelBuilder>();

            var handleExcel = new HandlerExcel(mapper, punterAnalysisService, configurationService, excelBuilder);

            // Act
            await handleExcel.Handle(new PlayForFun.Summary.Model.HttpParameterExcel());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
                Arg.Any<PlayForFun.Summary.Model.ExcelViewModel>(),
                Arg.Any<ExcelSetting>(),
                Arg.Any<PlayForFun.Detail.Model.ExcelViewModel>(),
                Arg.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var emptySummaryExcelViewModel = new PlayForFun.Summary.Model.ExcelViewModel();

            var emptyDetailExcelViewModel = new PlayForFun.Detail.Model.ExcelViewModel();

            var summaryExcelSetting = new ExcelSetting
            {
                SheetName = "AnySheetName",
                StartRowIndex = 8,
                TemplatePath = "AnyTemplatePath",
                Title = "Any Title",
                TitleCellRange = "A1:E2"
            };

            var productDetailExcelSetting = new ExcelSetting
            {
                SheetName = "AnySheetName",
                StartRowIndex = 8,
                TemplatePath = "AnyTemplatePath",
                Title = "Any Title",
                TitleCellRange = "A1:E2"
            };

            var mapper = Substitute.For<IMapper>();
            mapper.Map<PlayForFun.Summary.Model.ExcelViewModel>(Arg.Any<ReportModelBase<SummaryModel>>()).Returns(emptySummaryExcelViewModel);
            mapper.Map<PlayForFun.Detail.Model.ExcelViewModel>(Arg.Any<ReportModelBase<DetailModel>>()).Returns(emptyDetailExcelViewModel);

            var punterAnalysisService = Substitute.For<PlayForFunService>();

            var configurationService = Substitute.For<ApplicationConfigurationService>();

            var excelBuilder = Substitute.For<PlayForFunExcelBuilder>();

            var handleExcel = Substitute.ForPartsOf<HandlerExcel>(mapper, punterAnalysisService, configurationService, excelBuilder);
            handleExcel.CreateSummarySetting(Arg.Any<string>()).Returns(summaryExcelSetting);
            handleExcel.CreateProductDetailSetting(Arg.Any<string>(), Arg.Any<string>()).Returns(productDetailExcelSetting);

            // Act
            await handleExcel.Handle(new PlayForFun.Summary.Model.HttpParameterExcel());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
                Arg.Is(emptySummaryExcelViewModel),
                Arg.Is(summaryExcelSetting),
                Arg.Is(emptyDetailExcelViewModel),
                Arg.Is(productDetailExcelSetting));
        }
    }
}
