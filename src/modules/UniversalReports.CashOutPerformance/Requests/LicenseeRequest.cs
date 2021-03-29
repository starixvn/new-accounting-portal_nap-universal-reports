using MediatR;
using System.Collections.Generic;
using UniversalReports.CashOutPerformance.Models;

namespace UniversalReports.CashOutPerformance.Requests
{
    public class LicenseeRequest : IRequest<IEnumerable<LicenseeModel>>
    {
    }
}
