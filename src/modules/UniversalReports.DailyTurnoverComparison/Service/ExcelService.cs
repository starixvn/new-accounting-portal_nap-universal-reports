using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using UniversalReports.Core.Configurations;

namespace UniversalReports.DailyTurnoverComparison.Service
{
    public interface ExcelService
    {
        ExcelPackage Export(List<DataTable> dataTables);
    }

    public class ExcelServiceImp : ExcelService
    {
        private readonly ConfigurationService configurationService;
        private readonly DateTimeService dateTimeService;

        public ExcelServiceImp(ConfigurationService configurationService, DateTimeService dateTimeService)
        {
            this.configurationService = configurationService;
            this.dateTimeService = dateTimeService;
        }

        public ExcelPackage Export(List<DataTable> dataTables)
        {
            return dataTables.Count > 0
                ? ExportHasData(dataTables)
                : ExportNoData();
        }

        private ExcelPackage ExportHasData(List<DataTable> dataTables)
        {
            var excelPackage = new ExcelPackage(new FileInfo($"{configurationService.CurrentDirectory}/ExcelTemplate/TurnoverComparison/TurnoverComparison.xlsx"));
            var template = excelPackage.Workbook.Worksheets["Template"];
            excelPackage.Workbook.Worksheets.Delete(template);
            var sheetNumber = 1;

            dataTables.ForEach(dataTable =>
            {
                var sheet = excelPackage.Workbook.Worksheets.Add($"Sheet{sheetNumber}");
                RenderHeader(dataTable, template, sheet);
                RenderData(dataTable, sheet);
                sheetNumber++;
            });

            return excelPackage;
        }

        private ExcelPackage ExportNoData()
        {
            var excelPackage = new ExcelPackage(new FileInfo($"{configurationService.CurrentDirectory}/ExcelTemplate/TurnoverComparison/TurnoverComparison-NoData.xlsx"));
            var template = excelPackage.Workbook.Worksheets["No-Data"];
            template.Cells["A1"].Value = $"Daily Turnover Comparison Report From {dateTimeService.FromDate:yyyy-MM-dd} To {dateTimeService.ToDate:yyyy-MM-dd}";

            return excelPackage;
        }

        private void RenderHeader(DataTable dataTable, ExcelWorksheet template, ExcelWorksheet sheet)
        {
            var columnCount = dataTable.Columns.Count;
            var numberLicensee = (columnCount - 2) / 4;
            template.Cells[3, 1, 5, 2].Copy(sheet.Cells[3, 1, 5, 2]);
            template.Cells[1, 1].Copy(sheet.Cells[1, 1]);
            sheet.Cells[1, 1, 1, dataTable.Columns.Count].Merge = true;
            sheet.Cells["A1"].Value = $"Daily Turnover Comparison Report From {dateTimeService.FromDate:yyyy-MM-dd} To {dateTimeService.ToDate:yyyy-MM-dd}";
            sheet.Row(1).Height = 30;
            for (var licenseeIndex = 0; licenseeIndex < numberLicensee; licenseeIndex++)
            {
                var columnIndex = licenseeIndex * 4 + 2;
                var licenseeName = dataTable.Columns[columnIndex].ColumnName.Split('|')[0];
                if (licenseeIndex % 2 == 0)
                {
                    template.Cells[3, 3, 5, 6].Copy(sheet.Cells[3, columnIndex + 1]);
                }
                else
                {
                    template.Cells[3, 7, 5, 10].Copy(sheet.Cells[3, columnIndex + 1]);
                }
                sheet.Cells[3, columnIndex + 1].Value = licenseeName;
            }

            sheet.View.ShowGridLines = false;
            sheet.View.FreezePanes(5, 3);
        }

        private static void RenderData(DataTable dataTable, ExcelWorksheet sheet)
        {
            sheet.Cells["A5"].LoadFromDataTable(dataTable, false);
            const byte startRowIndex = 5;
            var maxRowIndex = dataTable.Rows.Count + startRowIndex - 1;
            var totalColumn = dataTable.Columns.Count;

            for (int columnIndex = 1; columnIndex <= totalColumn; columnIndex++)
            {
                sheet.Cells[startRowIndex, columnIndex, maxRowIndex, columnIndex].StyleID = sheet.Cells[startRowIndex, columnIndex].StyleID;
            }

            for (int rowIndex = startRowIndex; rowIndex <= maxRowIndex; rowIndex++)
            {
                var value = sheet.Cells[rowIndex, 2].Value.ToString();
                if (value.Contains(":"))
                {
                    sheet.Cells[rowIndex, 1].Value = value;
                    sheet.Cells[rowIndex, 1, rowIndex, 2].Merge = true;
                    sheet.Cells[rowIndex, 1, rowIndex, totalColumn].Style.Font.Bold = true;
                    sheet.Cells[rowIndex, 1, rowIndex, totalColumn].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    sheet.Cells[rowIndex, 1, rowIndex, totalColumn].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 242, 204));
                }
            }

            for (int columnIndex = 1; columnIndex <= totalColumn; columnIndex++)
            {
                sheet.Column(columnIndex).AutoFit();
            }
        }
    }
}