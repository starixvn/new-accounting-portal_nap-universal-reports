using MediatR;

namespace UniversalReports.PunterAnalysis.League.Model
{
    public class HttpParameterJson : IRequest<ViewModelJson>
    {
        public int PeriodType { get; set; }
    }
}