namespace UniversalReports.UpdatedUsernameAndGivenCredit.Common
{
    public interface ExcelSettingFactory
    {
        ExcelSetting CreateSetting(BaseMessage message);
    }
}
