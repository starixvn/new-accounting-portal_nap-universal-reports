using Linq.DynamicSum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.VoidingSettledTickets.Models;
using UniversalReports.VoidingSettledTickets.Requests;
using UniversalReports.VoidingSettledTickets.Services;

namespace UniversalReports.VoidingSettledTickets.Handlers
{
    public class Handler : RequestHandler<MoveBetsDateRequest, DateTime>,
        IRequestHandler<ProductRequest, SummaryEntity<ProductModel>>,
        IRequestHandler<TicketRequest, VoidTicketModel>

    {
        private readonly VoidingSettledService service;

        private readonly BalanceUpService balanceUpService;

        public Handler(VoidingSettledService service, BalanceUpService balanceUpService)
        {
            this.service = service;
            this.balanceUpService = balanceUpService;
        }

        public async Task<SummaryEntity<ProductModel>> Handle(ProductRequest request, CancellationToken cancellationToken)
          => await service.GetProducts(request);

        public async Task<VoidTicketModel> Handle(TicketRequest request, CancellationToken cancellationToken)
            => await service.GetTickets(request);

        protected override DateTime Handle(MoveBetsDateRequest request)
          => balanceUpService.Query().MoveBetsDate;
    }
}