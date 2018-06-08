using System.IO;
using Epplus.Mapper.Extensions;
using Linq.DynamicSum;
using OfficeOpenXml;
using UniversalReports.Core.Configurations;

namespace UniversalReports.Exchange.Report
{
    public interface ExcelBuilder
    {
        ExcelPackage Build(HttpParameterExcel excelParams, SummaryEntity<ExchangeExcelEntity> model);
    }

    public class ExcelBuilderImp : ExcelBuilder
    {

        private readonly ConfigurationService configurationService;

        private ExcelWorksheet exchangeSheet;

        private ExcelWorksheet totalSheet;

        private const int StartRowIndex = 5;

        private ExcelPackage ExcelPackage { get; set; }

        public ExcelBuilderImp(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelPackage Build(HttpParameterExcel excelParams, SummaryEntity<ExchangeExcelEntity> model)
        {
            LoadTemplate();
            BuilTitle(excelParams);
            exchangeSheet.ApplyVertical(model.Entities, StartRowIndex);
            exchangeSheet.ApplyModel(totalSheet, model.Total, StartRowIndex + model.Entities.Count);
            ClearTemplate();
            return ExcelPackage;
        }

        private void LoadTemplate()
        {
            var templateAbsolutelyPath = $"{configurationService.CurrentDirectory}\\ExcelTemplate\\Exchange\\Exchange.xlsx";
            using (var stream = new FileStream(templateAbsolutelyPath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                exchangeSheet = ExcelPackage.Workbook.Worksheets.Copy("ExchangeTemplate", "Exchange");
                totalSheet = ExcelPackage.Workbook.Worksheets["TotalTemplate"];
            }
        }

        private void BuilTitle(HttpParameterExcel excelParams)
        {
            var fromDate = $"{excelParams.FromDate: MMM dd, yyyy}";
            var toDate = $"{excelParams.ToDate: MMM dd, yyyy}";
            exchangeSheet.Cells["A1:N2"].Value = $"Exchange WinLoss From {fromDate} to {toDate}";
        }

        private void ClearTemplate()
        {
            ExcelPackage.Workbook.Worksheets.Delete("ExchangeTemplate");
            ExcelPackage.Workbook.Worksheets.Delete("TotalTemplate");
        }
    }
}
