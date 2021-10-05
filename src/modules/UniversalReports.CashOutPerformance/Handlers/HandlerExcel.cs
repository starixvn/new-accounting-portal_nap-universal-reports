using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.CashOutPerformance.Constants;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Requests;
using UniversalReports.CashOutPerformance.Services;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance.Handlers
{
    public class HandlerExcel : IRequestHandler<TicketExcelRequest<SportLevelModel>, ExcelPackage>,
        IRequestHandler<TicketExcelRequest<EventStatusLevelModel>, ExcelPackage>,
        IRequestHandler<TicketExcelRequest<BetTypeLevelModel>, ExcelPackage>,
        IRequestHandler<TicketExcelRequest<MatchDetailLevelModel>, ExcelPackage>
    {
        private readonly TicketsExcelBuilder<SportLevelExcelModel> ticketsSportExcelBuilder;
        private readonly TicketsExcelBuilder<EventStatusLevelExcelModel> ticketsEventExcelBuilder;
        private readonly TicketsExcelBuilder<BetTypeLevelExcelModel> ticketsBetTypeExcelBuilder;
        private readonly TicketsExcelBuilder<MatchDetailLevelExcelModel> ticketsMatchExcelBuilder;
        private readonly CashOutPerformanceService service;

        public HandlerExcel(TicketsExcelBuilder<SportLevelExcelModel> ticketsSportExcelBuilder,
            TicketsExcelBuilder<EventStatusLevelExcelModel> ticketsEventExcelBuilder,
            TicketsExcelBuilder<BetTypeLevelExcelModel> ticketsBetTypeExcelBuilder,
            TicketsExcelBuilder<MatchDetailLevelExcelModel> ticketsMatchExcelBuilder,
            CashOutPerformanceService service)
        {
            this.ticketsSportExcelBuilder = ticketsSportExcelBuilder;
            this.ticketsEventExcelBuilder = ticketsEventExcelBuilder;
            this.ticketsBetTypeExcelBuilder = ticketsBetTypeExcelBuilder;
            this.ticketsMatchExcelBuilder = ticketsMatchExcelBuilder;
            this.service = service;
        }

        public async Task<ExcelPackage> Handle(TicketExcelRequest<SportLevelModel> request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<SportLevelCriteria>(request);
            var reportData = await service.GetTickets<SportLevelModel, SportLevelCriteria>(criteria);
            var excelModel = Mapper.Map<TicketViewExcelModel<SportLevelExcelModel>>(reportData);
            var excelPackage = ticketsSportExcelBuilder.Build(request.Title, request.BreadCrumb, excelModel, ExcelType.Sport);
            return excelPackage;
        }

        public async Task<ExcelPackage> Handle(TicketExcelRequest<EventStatusLevelModel> request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<EventStatusLevelCriteria>(request);
            var reportData = await service.GetTickets<EventStatusLevelModel, EventStatusLevelCriteria>(criteria);
            var excelModel = Mapper.Map<TicketViewExcelModel<EventStatusLevelExcelModel>>(reportData);
            var sportName = new CultureInfo("en-US").TextInfo.ToTitleCase(request.BreadCrumb.Last().ToLowerInvariant());
            foreach (var item in excelModel.TicketList)
            {
                var status = item.LiveStatus == "0" ? "Non-Live" : "Live";
                item.LiveStatus = $"{sportName} {status}";
            }
            var excelPackage = ticketsEventExcelBuilder.Build(request.Title, request.BreadCrumb, excelModel, ExcelType.Event);
            return excelPackage;
        }

        public async Task<ExcelPackage> Handle(TicketExcelRequest<BetTypeLevelModel> request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<BetTypeLevelCriteria>(request);
            var reportData = await service.GetTickets<BetTypeLevelModel, BetTypeLevelCriteria>(criteria);
            var excelModel = Mapper.Map<TicketViewExcelModel<BetTypeLevelExcelModel>>(reportData);
            var excelPackage = ticketsBetTypeExcelBuilder.Build(request.Title, request.BreadCrumb, excelModel, ExcelType.BetType);
            return excelPackage;
        }

        public async Task<ExcelPackage> Handle(TicketExcelRequest<MatchDetailLevelModel> request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<MatchDetailLevelCriteria>(request);
            var reportData = await service.GetTickets<MatchDetailLevelModel, MatchDetailLevelCriteria>(criteria);
            var excelModel = Mapper.Map<TicketViewExcelModel<MatchDetailLevelExcelModel>>(reportData);
            var excelPackage = ticketsMatchExcelBuilder.Build(request.Title, request.BreadCrumb, excelModel, ExcelType.Match);
            return excelPackage;
        }
    }
}