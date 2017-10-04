using MediatR;
using OfficeOpenXml;
using UniversalReports.UpdatedUsernameAndCredit.Common;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedUsername
{
    public class ExcelMessage : BaseMessage, IRequest<ExcelPackage>
    {
    }
}