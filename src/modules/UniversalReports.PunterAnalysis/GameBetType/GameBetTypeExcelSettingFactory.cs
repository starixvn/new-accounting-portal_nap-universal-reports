using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.GameBetType
{
    public class GameBetTypeExcelSettingFactory : ExcelSettingFactory
    {
        private const string TemplatePath = @"ExcelTemplate\PunterAnalysis\GameBettype.xlsx";

        private readonly ConfigurationService configurationService;

        public GameBetTypeExcelSettingFactory(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelSetting CreateSetting(ExcelSettingParams excelSettingParams)
        {
            return new ExcelSetting
            {
                SheetName = "Punter Analysis",
                StartRowIndex = 9,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = excelSettingParams.Title,
                TitleCellRange = "A1:M2",
                Filter = excelSettingParams.Filter,
                FilterCellRange = "A3:M5"
            };
        }
    }
}