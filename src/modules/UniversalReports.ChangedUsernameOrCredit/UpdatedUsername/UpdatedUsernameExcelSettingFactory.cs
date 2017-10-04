using UniversalReports.Core.Configurations;
using UniversalReports.UpdatedUsernameAndCredit.Common;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedUsername
{
    public class UpdatedUsernameExcelSettingFactory : ExcelSettingFactory
    {
        private const string TemplatePath = @"ExcelTemplate\UpdatedUsernameAndCredit\UpdatedUsername.xlsx";

        private readonly ConfigurationService configurationService;

        public UpdatedUsernameExcelSettingFactory(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelSetting CreateSetting(BaseMessage message)
        {
            return new ExcelSetting
            {
                SheetName = "Updated Username",
                StartRowIndex = 5,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = $"Updated Username report From {message.FromDate: MMM dd, yyyy} To  {message.ToDate: MMM dd, yyyy}",
                TitleCellRange = "A1:N2",
            };
        }
    }
}