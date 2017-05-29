using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly LeagueServiceFactory leagueServiceFactory;

        private readonly ExcelSettingFactory setting;

        private readonly LeagueExcelBuilder excelBuilder;

        public HandlerExcel(LeagueServiceFactory leagueServiceFactory, ExcelSettingFactory setting, LeagueExcelBuilder excelBuilder)
        {
            this.leagueServiceFactory = leagueServiceFactory;
            this.setting = setting;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var criteria = Mapper.Map<Criteria>(message);
            var leagueService = leagueServiceFactory.CreateLeagueService(message.PeriodType);
            var model = await leagueService.Query(criteria).ConfigureAwait(false);
            var excelSettingParams = Mapper.Map<ExcelSettingParams>(message);
            var excelSetting = setting.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(model, excelSetting);
            return excelPackage;
        }
    }
}
