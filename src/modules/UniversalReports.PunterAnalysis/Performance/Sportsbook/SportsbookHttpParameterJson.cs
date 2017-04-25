using MediatR;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Model;

namespace UniversalReports.PunterAnalysis.Performance.Sportsbook
{
    public class SportsbookHttpParameterJson : HttpParameterJson, IRequest<ViewModelJson>
    {
    }
}