using MediatR;
using OfficeOpenXml;
using UniversalReports.UpdatedUsernameAndGivenCredit.Common;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername
{
    public class ExcelMessage : BaseMessage, IRequest<ExcelPackage>
    {
    }
}
