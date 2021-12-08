using Epplus.Mapper.Extensions;
using OfficeOpenXml;
using System;
using System.IO;
using UniversalReports.CashOutPerformance.Constants;
using UniversalReports.CashOutPerformance.ViewModels;
using UniversalReports.Core.Configurations;

namespace UniversalReports.CashOutPerformance.Services
{
    public interface TicketsExcelBuilder<T>
    {
        ExcelPackage Build(string title, string[] breadCrumb, TicketViewExcelModel<T> model, ExcelType excelType, bool IsShowFullColumn);
    }

    public class TicketsExcelBuilderImp<T> : TicketsExcelBuilder<T>
    {
        private readonly ConfigurationService configurationService;

        private ExcelWorksheet sheet;

        private ExcelWorksheet totalSheet;

        private const int StartRowIndex = 5;

        private ExcelPackage ExcelPackage { get; set; }

        public TicketsExcelBuilderImp(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelPackage Build(string title, string[] breadCrumb, TicketViewExcelModel<T> model, ExcelType excelType, bool IsShowFullColumn)
        {
            string fileExcel = "CashOutPerformance.xlsx";
            string cellAddressOfTitle = "A1:AC1";
            string cellAddressOfBreadCrumb = "A3:AC3";
            byte totalLength = 23;
            if (excelType != ExcelType.Match)
            {
                fileExcel = "SimpleCashOutPerformance.xlsx";
                cellAddressOfTitle = "A1:G1";
                cellAddressOfBreadCrumb = "A3:G3";
                totalLength = 1;
            }
            LoadTemplate(fileExcel);
            BuilTitle(title, cellAddressOfTitle);
            BuildBreadCrumb(breadCrumb, cellAddressOfBreadCrumb);
            RenameFirstColumn(excelType);
            sheet.ApplyVertical(model.TicketList, StartRowIndex);
            BuildTotalRow(model, totalLength);
            ClearTemplate();
            RemoveUsernameColumn(IsShowFullColumn);
            return ExcelPackage;
        }

        private void LoadTemplate(string fileExcel)
        {
            var templateAbsolutelyPath = $"{configurationService.CurrentDirectory}\\ExcelTemplate\\CashOutPerformance\\{fileExcel}";
            using (var stream = new FileStream(templateAbsolutelyPath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                sheet = ExcelPackage.Workbook.Worksheets.Copy("BodyTemplate", "Cash Out");
                totalSheet = ExcelPackage.Workbook.Worksheets["TotalTemplate"];
            }
        }

        private void BuildTotalRow(TicketViewExcelModel<T> model, byte totalLength)
        {
            var endRowIndex = StartRowIndex + model.Total;
            sheet.ApplyModel(totalSheet, model.TotalTicket, StartRowIndex + model.Total);
            var cellAddressOfTotalText = new ExcelAddressBase(endRowIndex, 1, endRowIndex, totalLength);
            sheet.Cells[cellAddressOfTotalText.Address].Value = "Grand Total";
            sheet.Cells[cellAddressOfTotalText.Address].Merge = true;
        }

        private void BuilTitle(string title, string cellRange)
        {
            sheet.Cells[cellRange].Value = title;
        }

        private void RenameFirstColumn(ExcelType excelType)
        {
            if (excelType != ExcelType.Match)
            {
                sheet.Cells["A4"].Value = Enum.GetName(typeof(ExcelType), excelType).Replace("Event", "Live/Non-Live");
            }
        }

        private void BuildBreadCrumb(string[] breadCrumb, string cellAddressOfBreadCrumb)
        {
            sheet.Cells[cellAddressOfBreadCrumb].Value = string.Join(" > ", breadCrumb);
        }

        private void ClearTemplate()
        {
            ExcelPackage.Workbook.Worksheets.Delete("BodyTemplate");
            ExcelPackage.Workbook.Worksheets.Delete("TotalTemplate");
        }

        private void RemoveUsernameColumn(bool IsShowFullColumn)
        {
            const byte usernameColumnIndex = 2;
            if (!IsShowFullColumn)
            {
                sheet.DeleteColumn(usernameColumnIndex);
                totalSheet.DeleteColumn(usernameColumnIndex);
            }
        }
    }
}