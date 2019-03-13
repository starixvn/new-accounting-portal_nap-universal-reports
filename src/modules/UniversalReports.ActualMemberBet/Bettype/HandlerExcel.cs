using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using UniversalReports.ActualMemberBet.Common;

namespace UniversalReports.ActualMemberBet.Bettype
{
    public class HandlerExcel : IRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly ActualMemberBetService service;

        private readonly BettypeExcelBuilder excelBuilder;

        public HandlerExcel(ActualMemberBetService service, BettypeExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<Criteria>(request);
            var bettypeActualMemberBet = await service.Query<BetTypeActualMemberBet>(criteria);
            var bettypeActualMemberBetExcel = Mapper.Map<SummaryEntity<BetTypeActualMemberBetExcel>>(bettypeActualMemberBet);
            var excelPackage = excelBuilder.Build(request, bettypeActualMemberBetExcel);
            return excelPackage;
        }
    }
}
