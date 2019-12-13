using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Game;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.Game
{
    public class GameExcelSettingFactoryUnitTests
    {
        [Test]
        public void CreateSetting_WithExcelSettingParametters_ReturnRightGameSetting()
        {
            // Arrange
            var excelSettingParams = new ExcelSettingParams
            {
                Title = "Any Title",
                Filter = "Any Filter"
            };

            var configurationService = Substitute.For<ConfigurationService>();
            configurationService.CurrentDirectory.Returns("D:");

            var expectedExcelSetting = new ExcelSetting
            {
                SheetName = "Punter Analysis",
                StartRowIndex = 8,
                TemplatePath = "D:\\ExcelTemplate\\PunterAnalysis\\Game.xlsx",
                Title = "Any Title",
                TitleCellRange = "A1:E2",
                Filter = "Any Filter",
                FilterCellRange = "A3:E5"
            };

            var setting = new GameExcelSettingFactory(configurationService);

            // Act
            var result = setting.CreateSetting(excelSettingParams);

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expectedExcelSetting));
        }
    }
}