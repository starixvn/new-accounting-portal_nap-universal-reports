using UniversalReports.Core.Configurations;
using UniversalReports.PlayForFun.Core;

namespace UniversalReports.PlayForFun.Detail
{
    public class DetailExcelSettingFactory : ExcelSettingFactory
    {
        private const string TemplatePath = @"ExcelTemplate\PlayForFun\Detail.xlsx";

        private readonly ApplicationConfigurationService configurationService;

        public DetailExcelSettingFactory(ApplicationConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelSetting CreateSetting(ExcelSettingParams excelSettingParams)
        {
            return new ExcelSetting
            {
                SheetName = "Punter Analysis",
                StartRowIndex = 8,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = excelSettingParams.Title,
                TitleCellRange = "A1:E2",
                Filter = excelSettingParams.Filter,
                FilterCellRange = "A3:E5"
            };
        }
    }
}