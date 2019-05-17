using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeOpenXml;
using UniversalReports.PunterAnalysis.League.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.League
{
    public class HandlerExcel : IRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly LeagueServiceFactory leagueServiceFactory;

        private readonly ExcelSettingFactory excelSettingFactory;

        private readonly LeagueExcelBuilder excelBuilder;

        public HandlerExcel(LeagueServiceFactory leagueServiceFactory, ExcelSettingFactory excelSettingFactory, LeagueExcelBuilder excelBuilder)
        {
            this.leagueServiceFactory = leagueServiceFactory;
            this.excelSettingFactory = excelSettingFactory;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<Criteria>(request);
            var leagueService = leagueServiceFactory.CreateLeagueService(request.PeriodType);
            var model = await leagueService.Query(criteria);
            var excelSettingParams = Mapper.Map<ExcelSettingParams>(request);
            var excelSetting = excelSettingFactory.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(model, excelSetting);
            return excelPackage;
        }
    }
}