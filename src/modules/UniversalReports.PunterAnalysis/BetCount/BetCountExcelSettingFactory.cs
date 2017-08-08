using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class BetCountExcelSettingFactory : ExcelSettingFactory
    {
        private const string TemplatePath = @"ExcelTemplate\PunterAnalysis\BetCount.xlsx";

        private readonly ConfigurationService configurationService;

        public BetCountExcelSettingFactory(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelSetting CreateSetting(ExcelSettingParams excelSettingParams)
        {
            return new ExcelSetting
            {
                SheetName = "Punter Analysis",
                StartRowIndex = 7,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = excelSettingParams.Title,
                TitleCellRange = "A1:E2",
                Filter = excelSettingParams.Filter,
                FilterCellRange = "A3:E4"
            };
        }
    }
}
