using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.VoidingSettledTickets.Models;
using UniversalReports.VoidingSettledTickets.Requests;
using UniversalReports.VoidingSettledTickets.Services;

namespace UniversalReports.VoidingSettledTickets.Handlers
{
    public class Handler : IRequestHandler<ProductRequest, List<ProductModel>>, IRequestHandler<TicketRequest, List<TicketModel>>
    {
        private readonly VoidingSettledService service;

        public Handler(VoidingSettledService service)
        {
            this.service = service;
        }

        public async Task<List<ProductModel>> Handle(ProductRequest request, CancellationToken cancellationToken)
          => await service.GetProducts(request);

        public async Task<List<TicketModel>> Handle(TicketRequest request, CancellationToken cancellationToken)
            => await service.GetTickets(request);
    }
}