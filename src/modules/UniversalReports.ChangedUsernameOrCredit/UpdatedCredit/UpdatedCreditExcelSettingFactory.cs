using UniversalReports.UpdatedUsernameCredit.Common;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedCredit
{
    using Configurations;

    public class UpdatedCreditExcelSettingFactory : ExcelSettingFactory
    {
        private const string TemplatePath = @"ExcelTemplate\UpdatedUsernameAndCredit\UpdatedCredit.xlsx";

        private readonly ConfigurationService configurationService;

        public UpdatedCreditExcelSettingFactory(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelSetting CreateSetting(BaseMessage message)
        {
            const int startDataRowTemplateIndex = 5;
            return new ExcelSetting
            {
                SheetName = "Updated Credit",
                StartRowIndex = startDataRowTemplateIndex,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = $"Updated Credit report From {message.FromDate:MMM dd, yyyy} To {message.ToDate:MMM dd, yyyy}",
                TitleCellRange = "A1:O2"
            };
        }
    }
}