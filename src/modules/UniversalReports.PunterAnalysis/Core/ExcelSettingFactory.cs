namespace UniversalReports.PunterAnalysis.Core
{
    public interface ExcelSettingFactory
    {
        ExcelSetting CreateSetting(ExcelSettingParams excelSettingParams);
    }
}
