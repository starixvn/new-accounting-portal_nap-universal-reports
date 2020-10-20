using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.VoidingSettledTickets.Criteria;
using UniversalReports.VoidingSettledTickets.Models;
using UniversalReports.VoidingSettledTickets.Requests;
using UniversalReports.VoidingSettledTickets.Services;

namespace UniversalReports.VoidingSettledTickets.Handlers
{
    public class HandlerExcel : IRequestHandler<ProductExcelRequest, ExcelPackage>,
                                IRequestHandler<TicketExcelRequest, ExcelPackage>

    {
        private readonly ProductExcelBuilder productExcelBuilder;

        private readonly TicketsExcelBuilder ticketsExcelBuilder;

        private readonly VoidingSettledService service;

        public HandlerExcel(VoidingSettledService service, ProductExcelBuilder productExcelBuilder, TicketsExcelBuilder ticketExcelBuilder)
        {
            this.service = service;
            this.productExcelBuilder = productExcelBuilder;
            this.ticketsExcelBuilder = ticketExcelBuilder;
        }

        public async Task<ExcelPackage> Handle(ProductExcelRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<ProductCriteria>(request);
            var products = await service.GetProducts<ProductModel>(criteria);
            var productsExcel = Mapper.Map<SummaryEntity<ProductExcelModel>>(products);
            var excelPackage = productExcelBuilder.Build(productsExcel);
            return excelPackage;
        }

        public async Task<ExcelPackage> Handle(TicketExcelRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<TicketCriteria>(request);
            var tickets = await service.GetTickets(criteria);
            var excelPackage = ticketsExcelBuilder.Build(request.productName, tickets);
            return excelPackage;
        }
    }
}