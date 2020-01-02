using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Summary;

namespace UniversalReports.PunterAnalysis.BetTypeGroup
{
    public class BetTypeGroupExcelSettingFactory : SummaryExcelSettingFactory
    {
        public BetTypeGroupExcelSettingFactory(ConfigurationService configurationService) : base(configurationService)
        {
        }

        protected override string TemplatePath => @"ExcelTemplate\PunterAnalysis\BetTypeGroup.xlsx";
    }
}