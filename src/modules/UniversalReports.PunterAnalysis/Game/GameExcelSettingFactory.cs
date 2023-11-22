using UniversalReports.PunterAnalysis.Summary;

namespace UniversalReports.PunterAnalysis.Game
{
    using Configurations;

    public class GameExcelSettingFactory : SummaryExcelSettingFactory
    {
        public GameExcelSettingFactory(ConfigurationService configurationService) : base(configurationService)
        {
        }

        protected override string TemplatePath => @"ExcelTemplate\PunterAnalysis\Game.xlsx";
    }
}