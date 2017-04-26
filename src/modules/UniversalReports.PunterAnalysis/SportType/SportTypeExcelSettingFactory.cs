using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary;

namespace UniversalReports.PunterAnalysis.SportType
{
    public class SportTypeExcelSettingFactory : SummaryExcelSettingFactory, ExcelSettingFactory
    {
        public SportTypeExcelSettingFactory(ApplicationConfigurationService configurationService) : base(configurationService)
        {
        }

        protected override string TemplatePath => @"ExcelTemplate\PunterAnalysis\Sporttype.xlsx";
    }
}
