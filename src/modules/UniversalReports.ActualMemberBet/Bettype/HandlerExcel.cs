using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using UniversalReports.ActualMemberBet.Common;

namespace UniversalReports.ActualMemberBet.Bettype
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly ActualMemberBetService service;

        private readonly BettypeExcelBuilder excelBuilder;

        public HandlerExcel(ActualMemberBetService service, BettypeExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var criteria = Mapper.Map<Criteria>(message);
            var bettypeActualMemberBet = await service.Query<BetTypeActualMemberBet>(criteria).ConfigureAwait(false);
            var bettypeActualMemberBetExcel = Mapper.Map<SummaryEntity<BetTypeActualMemberBetExcel>>(bettypeActualMemberBet);
            var excelPackage = excelBuilder.Build(message, bettypeActualMemberBetExcel);
            return excelPackage;
        }
    }
}
