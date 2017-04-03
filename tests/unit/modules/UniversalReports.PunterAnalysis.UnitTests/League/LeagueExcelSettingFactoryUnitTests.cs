using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.League;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class LeagueExcelSettingFactoryUnitTests
    {
        [Test]
        public async Task CreateSetting_WithExcelSettingParametters_ReturnRightLeagueSetting()
        {
            // Arrange
            var excelSettingParams = new ExcelSettingParams
            {
                Title = "Any Title",
                Filter = "Any Filter"
            };

            var configurationService = Substitute.For<ApplicationConfigurationService>();
            configurationService.CurrentDirectory.Returns<string>("D:");

            var expectedExcelSetting = new ExcelSetting
            {
                SheetName = "Punter Analysis",
                StartRowIndex = 8,
                TemplatePath = "D:\\ExcelTemplate\\PunterAnalysis\\League.xlsx",
                Title = "Any Title",
                TitleCellRange = "A1:E2",
                Filter = "Any Filter",
                FilterCellRange = "A3:E5"
            };

            var setting = new LeagueExcelSettingFactory(configurationService);

            // Act
            var result = await setting.CreateSetting(excelSettingParams);

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expectedExcelSetting));
        }
    }
}
