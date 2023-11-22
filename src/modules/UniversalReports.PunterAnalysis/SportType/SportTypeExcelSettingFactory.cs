using UniversalReports.PunterAnalysis.Summary;

namespace UniversalReports.PunterAnalysis.SportType
{
    using Configurations;

    public class SportTypeExcelSettingFactory : SummaryExcelSettingFactory
    {
        public SportTypeExcelSettingFactory(ConfigurationService configurationService) : base(configurationService)
        {
        }

        protected override string TemplatePath => @"ExcelTemplate\PunterAnalysis\Sporttype.xlsx";
    }
}