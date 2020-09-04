using OfficeOpenXml;
using System;
using System.IO;
using UniversalReports.Core.Configurations;

namespace UniversalReports.SMAWinLoss.Summary
{
    public interface ExcelBuilder
    {
        ExcelPackage Build(string title, WinLossModel winlosses);
    }

    public class ExcelBuilderImp : ExcelBuilder
    {
        private readonly ConfigurationService configurationService;

        private ExcelWorksheet summarySheet;

        private ExcelWorksheet summaryEvenSheet;

        private ExcelWorksheet summaryOddSheet;

        private ExcelWorksheet totalSheet;

        private const int StartRowIndex = 4;

        private const int StartColIndex = 1;

        private const int EndColIndex = 17;

        private const int NumberRowPerUser = 5;

        private const int StartMonthlyColIndex = 4;

        private ExcelPackage ExcelPackage { get; set; }

        public ExcelBuilderImp(ConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public ExcelPackage Build(string title, WinLossModel winlosses)
        {
            LoadTemplate();
            BuilTitle(title);
            BuildBody(winlosses);
            BuildTotal(winlosses);
            ClearTemplate();
            return ExcelPackage;
        }

        private void LoadTemplate()
        {
            var templateAbsolutelyPath = $"{configurationService.CurrentDirectory}\\ExcelTemplate\\SMAWinLoss\\Summary.xlsx";
            using (var stream = new FileStream(templateAbsolutelyPath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                summarySheet = ExcelPackage.Workbook.Worksheets.Copy("SummaryOdd", "SMA Win Loss Summary");
                summaryEvenSheet = ExcelPackage.Workbook.Worksheets["SummaryEven"];
                summaryOddSheet = ExcelPackage.Workbook.Worksheets["SummaryOdd"];
                totalSheet = ExcelPackage.Workbook.Worksheets["Total"];
            }
        }

        private void BuilTitle(string title)
        {
            summarySheet.Cells["A1:Q1"].Value = title;
        }

        private void BuildBody(WinLossModel winlosses)
        {
            var rowIndex = StartRowIndex;
            foreach (var item in winlosses.UsernameWinLosses)
            {
                BuildRow(item, rowIndex);
                rowIndex++;
            }
        }

        private void BuildTotal(WinLossModel winlosses)
        {
            var rowIndex = StartRowIndex + winlosses.UsernameWinLosses.Count;
            foreach (var item in winlosses.Total)
            {
                BuildTotalRow(item, rowIndex);
                rowIndex++;
            }

            summarySheet.Cells[$"A{rowIndex - 3}:B{rowIndex - 1}"].Merge = true;
        }

        private void BuildRow(UsernameWinLoss username, int rowIndex)
        {
            var userIndex = Convert.ToInt32((rowIndex - StartRowIndex) / NumberRowPerUser);
            if (userIndex % 2 == 0)
            {
                summaryEvenSheet
                    .Cells[StartRowIndex, StartColIndex, StartRowIndex, EndColIndex]
                    .Copy(summarySheet.Cells[rowIndex, StartColIndex, rowIndex, EndColIndex]);
            }
            else
            {
                summaryOddSheet
                    .Cells[StartRowIndex, StartColIndex, StartRowIndex, EndColIndex]
                    .Copy(summarySheet.Cells[rowIndex, StartColIndex, rowIndex, EndColIndex]);
            }

            var monthlyColIndex = StartMonthlyColIndex;
            summarySheet.Cells[$"A{rowIndex}:A{rowIndex}"].Value = username.Username;
            summarySheet.Cells[$"B{rowIndex}:B{rowIndex}"].Value = username.Currency;
            summarySheet.Cells[$"C{rowIndex}:C{rowIndex}"].Value = username.Name;

            foreach (var month in username.Months)
            {
                summarySheet.Cells[rowIndex, monthlyColIndex].Value = month.Value;
                monthlyColIndex++;
            }

            summarySheet.Cells[$"Q{rowIndex}:Q{rowIndex}"].Value = username.VirtualRate ? "View" : "Disabled";
        }

        private void BuildTotalRow(UsernameWinLoss username, int rowIndex)
        {
            totalSheet
                .Cells[StartRowIndex, StartColIndex, StartRowIndex, EndColIndex]
                .Copy(summarySheet.Cells[rowIndex, StartColIndex, rowIndex, EndColIndex]);
            var monthlyColIndex = StartMonthlyColIndex;
            summarySheet.Cells[$"A{rowIndex}:A{rowIndex}"].Value = username.Username;
            summarySheet.Cells[$"B{rowIndex}:B{rowIndex}"].Value = username.Currency;
            summarySheet.Cells[$"C{rowIndex}:C{rowIndex}"].Value = username.Name;

            foreach (var month in username.Months)
            {
                summarySheet.Cells[rowIndex, monthlyColIndex].Value = month.Value;
                monthlyColIndex++;
            }
        }

        private void ClearTemplate()
        {
            ExcelPackage.Workbook.Worksheets.Delete("SummaryOdd");
            ExcelPackage.Workbook.Worksheets.Delete("SummaryEven");
            ExcelPackage.Workbook.Worksheets.Delete("Total");
        }
    }
}