using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Summary;

namespace UniversalReports.PunterAnalysis.Game
{
    public class GameExcelSettingFactory : SummaryExcelSettingFactory
    {
        public GameExcelSettingFactory(ConfigurationService configurationService) : base(configurationService)
        {
        }

        protected override string TemplatePath => @"ExcelTemplate\PunterAnalysis\Game.xlsx";
    }
}