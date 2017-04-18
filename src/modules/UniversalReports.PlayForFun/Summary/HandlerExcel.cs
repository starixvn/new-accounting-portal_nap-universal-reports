using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Summary
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly IMapper mapper;

        private readonly PlayForFunService playForFunService;

        private readonly ExcelSettingFactory setting;

        private readonly PlayForFunExcelBuilder excelBuilder;

        public HandlerExcel(IMapper mapper, PlayForFunService playForFunService, ExcelSettingFactory setting, PlayForFunExcelBuilder excelBuilder)
        {
            this.mapper = mapper;
            this.playForFunService = playForFunService;
            this.setting = setting;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var criteria = mapper.Map<Criteria>(message);
            var model = await playForFunService.Query<SummaryModel>(criteria);
            var excelViewModel = mapper.Map<ExcelViewModel>(model);
            var excelSettingParams = mapper.Map<ExcelSettingParams>(message);
            var excelSetting = setting.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return await Task.FromResult(excelPackage);
        }
    }
}