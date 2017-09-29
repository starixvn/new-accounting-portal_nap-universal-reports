using UniversalReports.Core.Configurations;
using UniversalReports.UpdatedUsernameAndGivenCredit.Common;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedCredit
{
    public class UpdatedCreditExcelSettingFactory : ExcelSettingFactory
    {
        private const string TemplatePath = @"ExcelTemplate\UpdatedUsernameAndGivenCredit\UpdatedCredit.xlsx";

        private readonly ConfigurationService configurationService;

        public UpdatedCreditExcelSettingFactory(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelSetting CreateSetting(BaseMessage message)
        {
            return new ExcelSetting
            {
                SheetName = "Updated Credit",
                StartRowIndex = 5,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = $"Updated Credit report From {message.FromDate: MMM dd, yyyy} To  {message.ToDate: MMM dd, yyyy}",
                TitleCellRange = "A1:O2",
            };
        }
    }
}
