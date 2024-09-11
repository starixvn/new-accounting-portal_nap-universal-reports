using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.BetConstructPerformance.Criteria;
using UniversalReports.BetConstructPerformance.Models;
using UniversalReports.BetConstructPerformance.Requests;
using UniversalReports.BetConstructPerformance.Services;

namespace UniversalReports.BetConstructPerformance.Handlers
{
    public class ExcelHandler : IRequestHandler<SportExcelRequest, ExcelPackage>
    {
        private readonly BetConstructPerformanceService service;
        private readonly ExcelBuilderService excelService;

        public ExcelHandler(BetConstructPerformanceService service, ExcelBuilderService excelService)
        {
            this.service = service;
            this.excelService = excelService;
        }

        public async Task<ExcelPackage> Handle(SportExcelRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<SportCriteria>(request);
            var data = await service.GetSports(criteria);
            if (request.SportId.HasValue)
            {
                var excelModel = Mapper.Map<SportDetailExcelModel>(data);
                return excelService.BuildSportDetail(request.SportName, excelModel);
            }
            else
            {
                var excelModel = Mapper.Map<SportExcelModel>(data);
                return excelService.BuildSport($"BetConstruct Performance Report From {criteria.FromDate:MMM dd, yyyy} To {criteria.ToDate:MMM dd, yyyy}", excelModel);
            }

        }
    }
}
