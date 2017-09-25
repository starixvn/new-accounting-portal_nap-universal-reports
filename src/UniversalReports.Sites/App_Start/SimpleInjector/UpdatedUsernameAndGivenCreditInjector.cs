using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedCredit;
using UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername;

namespace UniversalReports.Sites.SimpleInjector
{
    internal static class UpdatedUsernameAndGivenCreditInjector
    {
            internal static Container RegisterUpdatedUsernameAndGivenCreditServices(this Container container)
            {
                container.Register<UpdatedUsernameService, UpdatedUsernameServiceImp>();
                container.Register<UpdatedCreditService, UpdatedCreditServiceImp>();
                container.Register<LogParseService, LogParseServiceImp>();

            return container;
            }
    }
}