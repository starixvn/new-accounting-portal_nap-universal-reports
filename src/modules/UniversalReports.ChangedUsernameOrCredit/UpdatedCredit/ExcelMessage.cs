using MediatR;
using OfficeOpenXml;
using UniversalReports.UpdatedUsernameAndCredit.Common;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedCredit
{
    public class ExcelMessage : BaseMessage, IRequest<ExcelPackage>
    {
    }
}