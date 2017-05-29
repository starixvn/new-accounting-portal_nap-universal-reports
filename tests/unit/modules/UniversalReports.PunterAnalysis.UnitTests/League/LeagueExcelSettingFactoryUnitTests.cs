using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.League;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class LeagueExcelSettingFactoryUnitTests
    {
        [Test]
        public void CreateSetting_WithExcelSettingParametters_ReturnRightLeagueSetting()
        {
            // Arrange
            var excelSettingParams = new ExcelSettingParams
            {
                Title = "Any Title",
                Filter = "Any Filter"
            };

            var configurationService = Substitute.For<ApplicationConfigurationService>();
            configurationService.CurrentDirectory.Returns("D:");

            var expectedExcelSetting = new ExcelSetting
            {
                SheetName = "Punter Analysis",
                StartRowIndex = 7,
                TemplatePath = "D:\\ExcelTemplate\\PunterAnalysis\\League.xlsx",
                Title = "Any Title",
                TitleCellRange = "A1:E2",
                Filter = "Any Filter",
                FilterCellRange = "A3:E5"
            };

            var setting = new LeagueExcelSettingFactory(configurationService);

            // Act
            var result = setting.CreateSetting(excelSettingParams);

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expectedExcelSetting));
        }
    }
}