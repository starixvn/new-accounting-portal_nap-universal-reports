using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class SummaryExcelSettingFactory : ExcelSettingFactory
    {
        private readonly ConfigurationService configurationService;

        public SummaryExcelSettingFactory(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        protected virtual string TemplatePath => @"ExcelTemplate\PunterAnalysis\Summary.xlsx";

        public ExcelSetting CreateSetting(ExcelSettingParams excelSettingParams)
        {
            return new ExcelSetting
            {
                SheetName = "Punter Analysis",
                StartRowIndex = 8,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = excelSettingParams.Title,
                TitleCellRange = "A1:E2",
                Filter = excelSettingParams.Filter,
                FilterCellRange = "A3:E5"
            };
        }
    }
}