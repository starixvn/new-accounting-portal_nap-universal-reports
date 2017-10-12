using MediatR;
using OfficeOpenXml;
using UniversalReports.UpdatedUsernameCredit.Common;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedCredit
{
    public class ExcelMessage : BaseMessage, IRequest<ExcelPackage>
    {
    }
}