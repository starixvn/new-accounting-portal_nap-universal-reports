using System.Threading.Tasks;

namespace UniversalReports.PunterAnalysis.Core
{
    public interface IExcelSetting
    {
        Task<ExcelSetting> CreateSetting(ExcelSettingParams excelSettingParams);
    }
}
