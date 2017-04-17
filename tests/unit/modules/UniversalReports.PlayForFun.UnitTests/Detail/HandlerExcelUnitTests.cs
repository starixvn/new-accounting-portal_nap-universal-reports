using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Detail;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.UnitTests.Detail
{
    public class HandlerExcelUnitTests
    {
        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        {
            // Arrange
            var mapper = Substitute.For<IMapper>();
            var punterAnalysisService = Substitute.For<PlayForFunService>();
            var excelSetting = Substitute.For<ExcelSettingFactory>();
            var excelBuilder = Substitute.For<PlayForFunExcelBuilder>();
            var handleExcel = new HandlerExcel(mapper, punterAnalysisService, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Any<ExcelViewModel>(), Arg.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var emptyExcelViewModel = new ExcelViewModel();
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
            mapper.Map<ExcelViewModel>(Arg.Any<ReportModelBase<DetailModel>>()).Returns(emptyExcelViewModel);
            var punterAnalysisService = Substitute.For<PlayForFunService>();
            var excelSetting = Substitute.For<ExcelSettingFactory>();
            excelSetting.CreateSetting(Arg.Any<ExcelSettingParams>()).Returns(settings);
            var excelBuilder = Substitute.For<PlayForFunExcelBuilder>();
            var handleExcel = new HandlerExcel(mapper, punterAnalysisService, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Is(emptyExcelViewModel), Arg.Is(settings));
        }
    }
}
