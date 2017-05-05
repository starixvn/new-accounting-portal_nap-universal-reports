using MediatR;
using UniversalReports.PunterAnalysis.Performance.Summary.Model;

namespace UniversalReports.PunterAnalysis.Performance.Summary
{
    public class SummaryHttpParameterJson : HttpParameterJson, IRequest<ViewModelJson>
    {
    }
}