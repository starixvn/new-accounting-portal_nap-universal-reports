using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SMAWinLoss.Summary
{
    public class HandlerExcel : IRequestHandler<WinLossHttpParameterExcel, ExcelPackage>
    {
        private readonly WinLossService service;

        private readonly ExcelBuilder excelBuilder;

        public HandlerExcel(WinLossService service, ExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(WinLossHttpParameterExcel request, CancellationToken cancellationToken)
        {
            var jsonMessage = Mapper.Map<WinLossHttpParameter>(request);
            var winlosses = await service.GetSMAWinLoss(jsonMessage);
            var excelPackage = excelBuilder.Build(request.Year, request.Title, winlosses);
            return excelPackage;
        }
    }
}