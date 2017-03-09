using MediatR;

namespace UniversalReports.PunterAnalysis.AssociatedAccount.Model
{
    public class HttpParameterJson : IRequest<ViewModelJson>
    {
        public int CustId { get; set; }

        public string Username { get; set; }
    }
}