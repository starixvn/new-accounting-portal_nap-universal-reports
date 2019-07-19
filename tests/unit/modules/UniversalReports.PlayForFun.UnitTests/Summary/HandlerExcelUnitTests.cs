using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
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
            var punterAnalysisService = Substitute.For<PlayForFunService>();

            var configurationService = Substitute.For<ConfigurationService>();
            configurationService.CurrentDirectory.Returns(string.Empty);

            var excelBuilder = Substitute.For<ExcelBuilder>();

            var handleExcel = new HandlerExcel(punterAnalysisService, configurationService, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
                Arg.Compat.Any<SummaryEntity<SummaryExcelModel>>(),
                Arg.Compat.Any<ExcelSetting>(),
                Arg.Compat.Any<SummaryEntity<DetailExcelModel>>(),
                Arg.Compat.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
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

            var punterAnalysisService = Substitute.For<PlayForFunService>();
            punterAnalysisService.Query<SummaryModel>(Arg.Compat.Any<SummaryCriteria>()).Returns(new SummaryEntity<SummaryModel>());
            punterAnalysisService.Query<DetailModel>(Arg.Compat.Any<DetailCriteria>()).Returns(new SummaryEntity<DetailModel>());

            var configurationService = Substitute.For<ConfigurationService>();
            configurationService.CurrentDirectory.Returns(string.Empty);

            var excelBuilder = Substitute.For<ExcelBuilder>();

            var handleExcel = Substitute.ForPartsOf<HandlerExcel>(punterAnalysisService, configurationService, excelBuilder);
            handleExcel.CreateSummarySetting(Arg.Compat.Any<string>()).Returns(summaryExcelSetting);
            handleExcel.CreateProductDetailSetting(Arg.Compat.Any<string>(), Arg.Compat.Any<string>()).Returns(productDetailExcelSetting);

            // Act
            await handleExcel.Handle(new HttpParameterExcel(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
               Arg.Compat.Is<SummaryEntity<SummaryExcelModel>>(x => x.Entities.Count == 0 && x.Total == null),
               Arg.Compat.Is(summaryExcelSetting),
               Arg.Compat.Is<SummaryEntity<DetailExcelModel>>(x => x.Entities.Count == 0 && x.Total == null),
               Arg.Compat.Is(productDetailExcelSetting));
        }
    }
}