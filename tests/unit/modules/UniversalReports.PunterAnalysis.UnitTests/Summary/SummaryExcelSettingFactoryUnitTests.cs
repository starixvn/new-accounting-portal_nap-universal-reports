using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.Summary;

namespace UniversalReports.PunterAnalysis.UnitTests.Summary
{
    public class SummaryExcelSettingFactoryUnitTests
    {
        [Test]
        public void CreateSetting_WithExcelSettingParametters_ReturnRightSummarySetting()
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
                StartRowIndex = 8,
                TemplatePath = "D:\\ExcelTemplate\\PunterAnalysis\\Summary.xlsx",
                Title = "Any Title",
                TitleCellRange = "A1:E2",
                Filter = "Any Filter",
                FilterCellRange = "A3:E5"
            };

            var setting = new SummaryExcelSettingFactory(configurationService);

            // Act
            var result = setting.CreateSetting(excelSettingParams);

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expectedExcelSetting));
        }
    }
}