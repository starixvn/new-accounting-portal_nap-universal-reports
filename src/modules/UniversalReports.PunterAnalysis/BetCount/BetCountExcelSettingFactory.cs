using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.BetCount
{
    using Configurations;

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
            const int startDataRowTemplateIndex = 10;
            return new ExcelSetting
            {
                SheetName = "Punter Analysis",
                StartRowIndex = startDataRowTemplateIndex,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = excelSettingParams.Title,
                TitleCellRange = "A1:E2",
                Filter = excelSettingParams.Filter,
                FilterCellRange = "A3:E7"
            };
        }
    }
}