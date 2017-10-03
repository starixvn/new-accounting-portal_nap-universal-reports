using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversalReports.UpdatedUsernameAndCredit.Common;
using UniversalReports.UpdatedUsernameAndCredit.UpdatedCredit;
using UniversalReports.UpdatedUsernameAndCredit.UpdatedUsername;

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
               c => c.Consumer.ImplementationType == typeof(UpdatedUsernameAndCredit.UpdatedCredit.HandlerExcel));
            container.RegisterConditional<ExcelSettingFactory, UpdatedUsernameExcelSettingFactory>(
              c => c.Consumer.ImplementationType == typeof(UpdatedUsernameAndCredit.UpdatedUsername.HandlerExcel));

            return container;
        }
    }
}