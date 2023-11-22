using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.VoidingSettledTickets.Criteria;
using UniversalReports.VoidingSettledTickets.Models;
using UniversalReports.VoidingSettledTickets.Requests;
using UniversalReports.VoidingSettledTickets.Services;

namespace UniversalReports.VoidingSettledTickets.Handlers
{
    using BalanceUpServices;

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
        {
            var criteria = Mapper.Map<ProductCriteria>(request);
            return await service.GetProducts<ProductModel>(criteria);
        }

        public async Task<VoidTicketModel> Handle(TicketRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<TicketCriteria>(request);
            return await service.GetTickets(criteria);
        }

        protected override DateTime Handle(MoveBetsDateRequest request)
          => balanceUpService.Query().MoveBetsDate;
    }
}