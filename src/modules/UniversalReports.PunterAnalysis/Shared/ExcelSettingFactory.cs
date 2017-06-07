namespace UniversalReports.PunterAnalysis.Shared
{
    public interface ExcelSettingFactory
    {
        ExcelSetting CreateSetting(ExcelSettingParams excelSettingParams);
    }
}
