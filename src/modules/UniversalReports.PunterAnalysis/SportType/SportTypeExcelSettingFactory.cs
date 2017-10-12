using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Summary;

namespace UniversalReports.PunterAnalysis.SportType
{
    public class SportTypeExcelSettingFactory : SummaryExcelSettingFactory
    {
        public SportTypeExcelSettingFactory(ConfigurationService configurationService) : base(configurationService)
        {
        }

        protected override string TemplatePath => @"ExcelTemplate\PunterAnalysis\Sporttype.xlsx";
    }
}