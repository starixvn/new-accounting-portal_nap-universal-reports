using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class SummaryExcelSettingFactory : IExcelSetting
    {
        private const string TemplatePath = @"ExcelTemplate\PunterAnalysis\Summary.xlsx";

        private readonly ApplicationConfigurationService configurationService;

        public SummaryExcelSettingFactory(ApplicationConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public async Task<ExcelSetting> CreateSetting(ExcelSettingParams excelSettingParams)
        {
            return await Task.FromResult(
                new ExcelSetting
                {
                    SheetName = "Punter Analysis",
                    StartRowIndex = 8,
                    TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                    Title = excelSettingParams.Title,
                    TitleCellRange = "A1:E2",
                    Filter = excelSettingParams.Filter,
                    FilterCellRange = "A3:E5"
                });
        }
    }
}