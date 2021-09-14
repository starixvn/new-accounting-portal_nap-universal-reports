using Epplus.Mapper.Extensions;
using OfficeOpenXml;
using System.IO;
using UniversalReports.CashOutPerformance.ViewModels;
using UniversalReports.Core.Configurations;

namespace UniversalReports.CashOutPerformance.Services
{
    public interface TicketsExcelBuilder
    {
        ExcelPackage Build(string title, TicketViewExcelModel model);
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

        public ExcelPackage Build(string title, TicketViewExcelModel model)
        {
            LoadTemplate();
            BuilTitle(title, "A1:U1");
            sheet.ApplyVertical(model.TicketList, StartRowIndex);
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

        private void BuildTotalRow(TicketViewExcelModel model)
        {
            var endRowIndex = StartRowIndex + model.Total;
            sheet.ApplyModel(totalSheet, model.TotalTicket, StartRowIndex + model.Total);
            var cellAddressOfTotalText = new ExcelAddressBase(endRowIndex, 1, endRowIndex, 17);
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