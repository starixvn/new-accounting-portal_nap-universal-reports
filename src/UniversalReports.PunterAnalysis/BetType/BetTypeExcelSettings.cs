using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetType
{
    public interface BetTypeExcelSettings
    {
        Task<ExcelSettings> CreateSettings();
    }

    public class BetTypeExcelSettingsImp : BetTypeExcelSettings
    {
        public async Task<ExcelSettings> CreateSettings()
        {
            return await Task.FromResult(
                new ExcelSettings
                {
                    SheetName = "aaa",
                    StartRowIndex = 5,
                    TemplatePath = "bbb",
                    Title = "ccc",
                    TitleCellRange = "A1:C3",
                    Description = "dddd",
                    DescriptionCellRange = "A4:C8"
                });
        }
    }
}
