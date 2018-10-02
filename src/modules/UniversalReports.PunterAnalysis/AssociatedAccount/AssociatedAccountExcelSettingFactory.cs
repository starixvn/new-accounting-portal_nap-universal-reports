using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.AssociatedAccount
{
    public class AssociatedAccountExcelSettingFactory : ExcelSettingFactory
    {
        private const string TemplatePath = @"ExcelTemplate\PunterAnalysis\AssociatedAccount.xlsx";

        private readonly ConfigurationService configurationService;

        public AssociatedAccountExcelSettingFactory(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelSetting CreateSetting(ExcelSettingParams excelSettingParams)
        {
            return new ExcelSetting
            {
                SheetName = "Punter Analysis",
                StartRowIndex = 8,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = excelSettingParams.Title,
                TitleCellRange = "A1:F2",
                Filter = excelSettingParams.Filter,
                FilterCellRange = "A3:F5"
            };
        }
    }

}
