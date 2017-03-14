using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetType;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.BetType
{
    public class HandlerExcelUnitTests
    {
        //[Test]
        //public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        //{
        //    // Arrange
        //    var mapper = Substitute.For<IMapper>();
        //    var punterAnalysisService = Substitute.For<PunterAnalysisService>();
        //    var excelSettings = Substitute.For<BetTypeExcelSettings>();
        //    var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
        //    var handleExcel = new HandlerExcel(mapper, punterAnalysisService, excelSettings, excelBuilder);

        //    // Act
        //    await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

        //    // Assert
        //    await excelBuilder.Received().CreateExcelPackage(Arg.Any<ExcelViewModel>(), Arg.Any<ExcelSettings>());
        //}

        //[Test]
        //public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        //{
        //    // Arrange
        //    var emptyExcelViewModel = new ExcelViewModel();
        //    var settings = new ExcelSettings
        //    {
        //        SheetName = "aaa",
        //        StartRowIndex = 5,
        //        TemplatePath = "bbb",
        //        Title = "ccc",
        //        TitleCellRange = "A1:C3",
        //        Description = "dddd",
        //        DescriptionCellRange = "A4:C8"
        //    };
        //    var mapper = Substitute.For<IMapper>();
        //    mapper.Map<ExcelViewModel>(Arg.Any<ReportModelBase<BetTypeModel>>()).Returns(emptyExcelViewModel);
        //    var punterAnalysisService = Substitute.For<PunterAnalysisService>();
        //    var excelSettings = Substitute.For<BetTypeExcelSettings>();
        //    excelSettings.CreateSettings().Returns(settings);
        //    var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
        //    var handleExcel = new HandlerExcel(mapper, punterAnalysisService, excelSettings, excelBuilder);

        //    // Act
        //    await handleExcel.Handle(Arg.Any<HttpParameterExcel>());

        //    // Assert
        //    await excelBuilder.Received().CreateExcelPackage(Arg.Is(emptyExcelViewModel), Arg.Is(settings));
        //}
    }
}
