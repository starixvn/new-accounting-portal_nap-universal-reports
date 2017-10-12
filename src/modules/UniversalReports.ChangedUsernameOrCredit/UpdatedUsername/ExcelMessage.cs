using MediatR;
using OfficeOpenXml;
using UniversalReports.UpdatedUsernameCredit.Common;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedUsername
{
    public class ExcelMessage : BaseMessage, IRequest<ExcelPackage>
    {
    }
}