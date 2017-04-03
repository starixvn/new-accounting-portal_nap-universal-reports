using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.SportType;

namespace UniversalReports.PunterAnalysis.UnitTests.SportType
{
    public class SportTypeExcelSettingFactoryUnitTests
    {
        [Test]
        public async Task CreateSetting_WithExcelSettingParametters_ReturnRightSportTypeSetting()
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
                TemplatePath = "D:\\ExcelTemplate\\PunterAnalysis\\Sporttype.xlsx",
                Title = "Any Title",
                TitleCellRange = "A1:E2",
                Filter = "Any Filter",
                FilterCellRange = "A3:E5"
            };

            var setting = new SportTypeExcelSettingFactory(configurationService);

            // Act
            var result = await setting.CreateSetting(excelSettingParams);

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expectedExcelSetting));
        }
    }
}
