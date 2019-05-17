using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.AssociatedAccount
{
    public class Handler : IRequestHandler<HttpParameterJson, SummaryEntity<AssociatedSummaryModel>>
    {
        private readonly AssociatedFacade associatedFacade;

        public Handler(AssociatedFacade associatedFacade)
        {
            this.associatedFacade = associatedFacade;
        }

        public async Task<SummaryEntity<AssociatedSummaryModel>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            return await associatedFacade.Query(request);
        }
    }
}