using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.BetType;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.BetType
{
    public class BetTypeExcelSettingFactoryUnitTests
    {
        [Test]
        public async Task CreateSetting_WithExcelSettingParametters_ReturnRightBetTypeSetting()
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
                StartRowIndex = 9,
                TemplatePath = "D:\\ExcelTemplate\\PunterAnalysis\\Bettype.xlsx",
                Title = "Any Title",
                TitleCellRange = "A1:M2",
                Filter = "Any Filter",
                FilterCellRange = "A3:M5"
            };

            var setting = new BetTypeExcelSettingFactory(configurationService);

            // Act
            var result = await setting.CreateSetting(excelSettingParams);

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expectedExcelSetting));
        }
    }
}
