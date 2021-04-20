using Epplus.Mapper.Extensions;
using Linq.DynamicSum;
using OfficeOpenXml;
using System.IO;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.Core.Configurations;

namespace UniversalReports.CashOutPerformance.Services
{
    public interface TicketsExcelBuilder
    {
        ExcelPackage Build(string title, SummaryEntity<TicketExcelModel> model);
    }

    public class TicketsExcelBuilderImp : TicketsExcelBuilder
    {
        private readonly ConfigurationService configurationService;

        private ExcelWorksheet sheet;

        private ExcelWorksheet totalSheet;

        private const int StartRowIndex = 4;

        private ExcelPackage ExcelPackage { get; set; }

        public TicketsExcelBuilderImp(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelPackage Build(string title, SummaryEntity<TicketExcelModel> model)
        {
            LoadTemplate();
            BuilTitle(title, "A1:U1");
            sheet.ApplyVertical(model.Entities, StartRowIndex);
            BuildTotalRow(model);
            ClearTemplate();
            return ExcelPackage;
        }

        private void LoadTemplate()
        {
            var templateAbsolutelyPath = $"{configurationService.CurrentDirectory}\\ExcelTemplate\\CashOutPerformance\\CashOutPerformance.xlsx";
            using (var stream = new FileStream(templateAbsolutelyPath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                sheet = ExcelPackage.Workbook.Worksheets.Copy("BodyTemplate", "Cash Out");
                totalSheet = ExcelPackage.Workbook.Worksheets["TotalTemplate"];
            }
        }

        private void BuildTotalRow(SummaryEntity<TicketExcelModel> model)
        {
            var endRowIndex = StartRowIndex + model.Entities.Count;
            sheet.ApplyModel(totalSheet, model.Total, StartRowIndex + model.Entities.Count);
            var cellAddressOfTotalText = new ExcelAddressBase(endRowIndex, 1, endRowIndex, 15);
            sheet.Cells[cellAddressOfTotalText.Address].Value = "Grand Total";
            sheet.Cells[cellAddressOfTotalText.Address].Merge = true;
        }

        private void BuilTitle(string title, string cellRange)
        {
            sheet.Cells[cellRange].Value = title;
        }

        private void ClearTemplate()
        {
            ExcelPackage.Workbook.Worksheets.Delete("BodyTemplate");
            ExcelPackage.Workbook.Worksheets.Delete("TotalTemplate");
        }
    }
}
