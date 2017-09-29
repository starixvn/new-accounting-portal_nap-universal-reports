using MediatR;
using OfficeOpenXml;
using UniversalReports.UpdatedUsernameAndGivenCredit.Common;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedCredit
{
    public class ExcelMessage : BaseMessage, IRequest<ExcelPackage>
    {
    }
}
