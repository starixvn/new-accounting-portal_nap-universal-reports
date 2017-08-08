using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Detail.Model;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Summary
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private const string TemplatePath = @"ExcelTemplate\PlayForFun\Summary.xlsx";

        private readonly PlayForFunService playForFunService;

        private readonly ConfigurationService configurationService;

        private readonly ExcelBuilder excelBuilder;

        public HandlerExcel(
            PlayForFunService playForFunService,
            ConfigurationService configurationService,
            ExcelBuilder excelBuilder)
        {
            this.playForFunService = playForFunService;
            this.configurationService = configurationService;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            var summaryCriteria = Mapper.Map<SummaryCriteria>(message);
            var summaryModel = await playForFunService.Query<SummaryModel>(summaryCriteria).ConfigureAwait(false);
            var summaryExcelViewModel = Mapper.Map<SummaryEntity<SummaryExcelModel>>(summaryModel);

            var detailCriteria = Mapper.Map<DetailCriteria>(message);
            var detailModel = await playForFunService.Query<DetailModel>(detailCriteria).ConfigureAwait(false);
            var detailExcelViewModel = Mapper.Map<SummaryEntity<DetailExcelModel>>(detailModel);

            var sumamryExcelSetting = CreateSummarySetting(message.Title);
            var detailExcelSetting = CreateProductDetailSetting(message.Title, message.ProductName);

            var excelPackage = excelBuilder.CreateExcelPackage(
                summaryExcelViewModel,
                sumamryExcelSetting,
                detailExcelViewModel,
                detailExcelSetting);

            return excelPackage;
        }

        public virtual ExcelSetting CreateSummarySetting(string title)
        {
            return new ExcelSetting
            {
                SheetName = "Summary",
                StartRowIndex = 4,
                TemplatePath = $"{configurationService.CurrentDirectory}\\{TemplatePath}",
                Title = title,
                TitleCellRange = "A1:E1",
                MergedColumnCountOfTotalRow = 1
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
                TitleCellRange = "A1:M1",
                MergedColumnCountOfTotalRow = 10
            };
        }
    }
}