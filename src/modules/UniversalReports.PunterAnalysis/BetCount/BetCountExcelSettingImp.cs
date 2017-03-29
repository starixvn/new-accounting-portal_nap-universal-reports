using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public class BetCountExcelSettingImp : IExcelSetting
    {
        private const string TemplatePath = @"ExcelTemplate\PunterAnalysis\BetCount.xlsx";

        private readonly ApplicationConfigurationService configurationService;

        public BetCountExcelSettingImp(ApplicationConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public async Task<ExcelSetting> CreateSetting(ExcelSettingParams excelSettingParams)
        {
            return await Task.FromResult(
                new ExcelSetting
                {
                    SheetName = "Punter Analysis",
                    StartRowIndex = 7,
                    TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                    Title = excelSettingParams.Title,
                    TitleCellRange = "A1:E2",
                    Filter = excelSettingParams.Filter,
                    FilterCellRange = "A3:E4"
                });
        }
    }
}
