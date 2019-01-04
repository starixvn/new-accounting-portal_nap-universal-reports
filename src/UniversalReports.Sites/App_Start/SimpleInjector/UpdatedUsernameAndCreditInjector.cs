using SimpleInjector;
using UniversalReports.UpdatedUsernameCredit.Common;
using UniversalReports.UpdatedUsernameCredit.UpdatedCredit;
using UniversalReports.UpdatedUsernameCredit.UpdatedUsername;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class UpdatedUsernameAndCreditInjector
    {
        internal static Container RegisterUpdatedUsernameAndCreditServices(this Container container)
        {
            container.Register<UpdatedUsernameService, UpdatedUsernameServiceImp>();
            container.Register<UpdatedCreditService, UpdatedCreditServiceImp>();
            container.Register<LogParseService, LogParseServiceImp>();
            container.Register<ExcelBuilder, ExcelBuilderImp>();
            container.RegisterConditional<ExcelSettingFactory, UpdatedCreditExcelSettingFactory>(
               c => c.Consumer.ImplementationType == typeof(UpdatedUsernameCredit.UpdatedCredit.HandlerExcel));
            container.RegisterConditional<ExcelSettingFactory, UpdatedUsernameExcelSettingFactory>(
              c => c.Consumer.ImplementationType == typeof(UpdatedUsernameCredit.UpdatedUsername.HandlerExcel));

            return container;
        }
    }
}