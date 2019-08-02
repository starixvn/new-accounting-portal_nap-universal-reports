using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.AssociatedAccount;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.AssociatedAccount
{
    public class HandlerExcelUnitTests
    {
        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        {
            // Arrange
            var facade = Substitute.For<AssociatedFacade>();
            var excelSettingFactory = Substitute.For<ExcelSettingFactory>();
            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(facade, excelSettingFactory, excelBuilder);

            // Act
            await handleExcel.Handle(Arg.Compat.Any<HttpParameterExcel>(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Compat.Any<SummaryEntity<AssociatedSummaryExcelModel>>(), Arg.Compat.Any<ExcelSetting>());
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
                FilterCellRange = "A3:E4"
            };

            var facade = Substitute.For<AssociatedFacade>();
            facade.Query(Arg.Compat.Any<HttpParameterJson>()).Returns(new SummaryEntity<AssociatedSummaryModel>());

            var excelSettingFactory = Substitute.For<ExcelSettingFactory>();
            excelSettingFactory.CreateSetting(Arg.Compat.Any<ExcelSettingParams>()).Returns(excelSetting);

            var excelBuilder = Substitute.For<PunterAnalysisExcelBuilder>();
            var handleExcel = new HandlerExcel(facade, excelSettingFactory, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel(), new CancellationToken());

            // Assert
            excelBuilder.Received().CreateExcelPackage(
               Arg.Compat.Is<SummaryEntity<AssociatedSummaryExcelModel>>(x => x.Entities.Count == 0 && x.Total == null),
               Arg.Compat.Is(excelSetting));
        }
    }
}