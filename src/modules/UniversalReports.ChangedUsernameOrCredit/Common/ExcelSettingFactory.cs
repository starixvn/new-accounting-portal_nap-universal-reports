namespace UniversalReports.UpdatedUsernameCredit.Common
{
    public interface ExcelSettingFactory
    {
        ExcelSetting CreateSetting(BaseMessage message);
    }
}