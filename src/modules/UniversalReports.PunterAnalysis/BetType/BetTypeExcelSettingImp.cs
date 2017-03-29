using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetType
{
    public class BetTypeExcelSettingsImp : IExcelSetting
    {
        private const string TemplatePath = @"ExcelTemplate\PunterAnalysis\Bettype.xlsx";

        private readonly ApplicationConfigurationService configurationService;

        public BetTypeExcelSettingsImp(ApplicationConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public async Task<ExcelSetting> CreateSetting(ExcelSettingParams excelSettingParams)
        {
            return await Task.FromResult(
                new ExcelSetting
                {
                    SheetName = "Punter Analysis",
                    StartRowIndex = 9,
                    TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                    Title = excelSettingParams.Title,
                    TitleCellRange = "A1:M2",
                    Filter = excelSettingParams.Filter,
                    FilterCellRange = "A3:M5"
                });
        }
    }
}
