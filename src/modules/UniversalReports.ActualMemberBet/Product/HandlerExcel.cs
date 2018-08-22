using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using UniversalReports.ActualMemberBet.Common;

namespace UniversalReports.ActualMemberBet.Product
{
    public class HandlerExcel : IRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly ActualMemberBetService service;

        private readonly ProductExcelBuilder excelBuilder;

        public HandlerExcel(ActualMemberBetService service, ProductExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<Criteria>(request);
            var productActualMemberBet = await service.Query<ProductActualMemberBet>(criteria).ConfigureAwait(false);
            var productActualMemberBetExcel = Mapper.Map<SummaryEntity<ProductActualMemberBetExcel>>(productActualMemberBet);
            var excelPackage = excelBuilder.Build(productActualMemberBetExcel);
            return excelPackage;
        }
    }
}
