namespace UniversalReports.UpdatedUsernameAndCredit.Common
{
    public interface ExcelSettingFactory
    {
        ExcelSetting CreateSetting(BaseMessage message);
    }
}