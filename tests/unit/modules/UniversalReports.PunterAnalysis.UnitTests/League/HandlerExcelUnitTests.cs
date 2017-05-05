using AutoMapper;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class HandlerExcelUnitTests
    {
        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackage()
        {
            // Arrange
            var emptyExcelViewModel = new ReportModel();
            var mapper = Substitute.For<IMapper>();
            var factory = CreateLeagueServiceFactory(emptyExcelViewModel);
            var excelSetting = Substitute.For<ExcelSettingFactory>();
            var excelBuilder = Substitute.For<LeagueExcelBuilder>();
            var handleExcel = new HandlerExcel(mapper, factory, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Any<ReportModel>(), Arg.Any<ExcelSetting>());
        }

        [Test]
        public async Task Handle_WithAnyParametters_ExecuteCreatePackageWithValidParameter()
        {
            // Arrange
            var emptyExcelViewModel = new ReportModel();
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
            var factory = CreateLeagueServiceFactory(emptyExcelViewModel);
            var excelSetting = Substitute.For<ExcelSettingFactory>();
            excelSetting.CreateSetting(Arg.Any<ExcelSettingParams>()).Returns(settings);
            var excelBuilder = Substitute.For<LeagueExcelBuilder>();
            var handleExcel = new HandlerExcel(mapper, factory, excelSetting, excelBuilder);

            // Act
            await handleExcel.Handle(new HttpParameterExcel());

            // Assert
            excelBuilder.Received().CreateExcelPackage(Arg.Is(emptyExcelViewModel), Arg.Is(settings));
        }

        private LeagueServiceFactory CreateLeagueServiceFactory(ReportModel reportModel)
        {
            var service = Substitute.For<LeagueService>();
            service.Query(Arg.Any<ICriteria>()).Returns(reportModel);

            var factory = Substitute.For<LeagueServiceFactory>();
            factory.CreateLeagueService(Arg.Any<int>()).Returns(service);

            return factory;
        }
    }
}
