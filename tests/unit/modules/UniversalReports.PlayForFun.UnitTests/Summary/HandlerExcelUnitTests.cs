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
            configurationService.CurrentDirectory.Returns(string.Empty);

            var excelBuilder = Substitute.For<ExcelBuilder>();

            var handleExcel = new HandlerExcel(mapper, punterAnalysisService, configurationService, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
                Arg.Any<ReportModelBase<SummaryExcelModel>>(),
                Arg.Any<ExcelSetting>(),
                Arg.Any<ReportModelBase<DetailExcelModel>>(),
                Arg.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var emptySummaryExcelViewModel = new ReportModelBase<SummaryExcelModel>();

            var emptyDetailExcelViewModel = new ReportModelBase<DetailExcelModel>();

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
            mapper.Map<ReportModelBase<SummaryExcelModel>>(Arg.Any<ReportModelBase<SummaryModel>>()).Returns(emptySummaryExcelViewModel);
            mapper.Map<ReportModelBase<DetailExcelModel>>(Arg.Any<ReportModelBase<DetailModel>>()).Returns(emptyDetailExcelViewModel);

            var punterAnalysisService = Substitute.For<PlayForFunService>();

            var configurationService = Substitute.For<ApplicationConfigurationService>();
            configurationService.CurrentDirectory.Returns(string.Empty);

            var excelBuilder = Substitute.For<ExcelBuilder>();

            var handleExcel = Substitute.ForPartsOf<HandlerExcel>(mapper, punterAnalysisService, configurationService, excelBuilder);
            handleExcel.CreateSummarySetting(Arg.Any<string>()).Returns(summaryExcelSetting);
            handleExcel.CreateProductDetailSetting(Arg.Any<string>(), Arg.Any<string>()).Returns(productDetailExcelSetting);

            // Act
            await handleExcel.Handle(new HttpParameterExcel());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
                Arg.Is(emptySummaryExcelViewModel),
                Arg.Is(summaryExcelSetting),
                Arg.Is(emptyDetailExcelViewModel),
                Arg.Is(productDetailExcelSetting));
        }
    }
}