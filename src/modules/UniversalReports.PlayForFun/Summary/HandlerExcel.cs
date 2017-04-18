using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Summary
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private const string TemplatePath = @"ExcelTemplate\PlayForFun\Summary.xlsx";

        private readonly IMapper mapper;

        private readonly PlayForFunService playForFunService;

        private readonly ApplicationConfigurationService configurationService;


        private readonly PlayForFunExcelBuilder excelBuilder;

        public HandlerExcel(IMapper mapper, PlayForFunService playForFunService, ApplicationConfigurationService configurationService, PlayForFunExcelBuilder excelBuilder)
        {
            this.mapper = mapper;
            this.playForFunService = playForFunService;
            this.configurationService = configurationService;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var summaryCriteria = mapper.Map<Criteria>(message);
            var summaryModel = await playForFunService.Query<SummaryModel>(summaryCriteria);
            var summaryExcelViewModel = mapper.Map<ExcelViewModel>(summaryModel);

            var detailCriteria = mapper.Map<Detail.Model.Criteria>(message);
            var detailModel = await playForFunService.Query<Detail.Model.DetailModel>(detailCriteria);
            var detailExcelViewModel = mapper.Map<Detail.Model.ExcelViewModel>(detailModel);

            var sumamryExcelSetting = CreateSummarySetting(message.Title);
            var detailExcelSetting = CreateProductDetailSetting(message.Title, message.ProductName);

            var excelPackage = excelBuilder.CreateExcelPackage(
                summaryExcelViewModel,
                sumamryExcelSetting,
                detailExcelViewModel,
                detailExcelSetting);
            return await Task.FromResult(excelPackage);
        }

        public virtual ExcelSetting CreateSummarySetting(string title)
        {
            return new ExcelSetting
            {
                SheetName = "Summary",
                StartRowIndex = 4,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = title,
                TitleCellRange = "A1:E1"
            };
        }

        public virtual ExcelSetting CreateProductDetailSetting(string title, string productName)
        {
            return new ExcelSetting
            {
                SheetName = $"{productName} Statistics",
                StartRowIndex = 4,
                TemplatePath = string.Empty,
                Title = title,
                TitleCellRange = "A1:M1"
            };
        }
    }
}