using MediatR;
using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.Performance.Summary
{
    public class HttpParameterJson : IRequest<IEnumerable<SummaryModel>>
    {
    }
}
