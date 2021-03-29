using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Requests;
using UniversalReports.CashOutPerformance.Services;

namespace UniversalReports.CashOutPerformance.Handlers
{
    public class HandlerExcel : IRequestHandler<TicketExcelRequest, ExcelPackage>
    {
        private readonly TicketsExcelBuilder ticketsExcelBuilder;

        private readonly CashOutPerformanceService service;

        public HandlerExcel(TicketsExcelBuilder ticketExcelBuilder, CashOutPerformanceService service)
        {
            this.ticketsExcelBuilder = ticketExcelBuilder;
            this.service = service;
        }

        public async Task<ExcelPackage> Handle(TicketExcelRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<TicketCriteria>(request);
            var reportData = await service.GetTickets(criteria);
            var excelModel = Mapper.Map<SummaryEntity<TicketExcelModel>>(reportData);
            var excelPackage = ticketsExcelBuilder.Build(request.Title, excelModel);
            return excelPackage;
        }
    }
}
