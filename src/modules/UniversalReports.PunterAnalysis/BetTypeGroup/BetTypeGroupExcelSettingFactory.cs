using UniversalReports.PunterAnalysis.Summary;

namespace UniversalReports.PunterAnalysis.BetTypeGroup
{
    using Configurations;

    public class BetTypeGroupExcelSettingFactory : SummaryExcelSettingFactory
    {
        public BetTypeGroupExcelSettingFactory(ConfigurationService configurationService) : base(configurationService)
        {
        }

        protected override string TemplatePath => @"ExcelTemplate\PunterAnalysis\BetTypeGroup.xlsx";
    }
}