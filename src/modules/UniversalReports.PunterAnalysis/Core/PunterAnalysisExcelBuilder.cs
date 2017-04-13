using Epplus.Mapper.Extensions;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace UniversalReports.PunterAnalysis.Core
{
    public interface PunterAnalysisExcelBuilder
    {
        ExcelPackage CreateExcelPackage<T>(ReportModelBase<T> model, ExcelSetting settings) where T : class, new();
    }

    public class PunterAnalysisExcelBuilderImp : PunterAnalysisExcelBuilder
    {
        private ExcelWorksheet statisticSheet;

        private ExcelWorksheet templateSheet;

        private ExcelWorksheet totalTemplateSheet;

        private int RowIndex { get; set; }

        private ExcelPackage ExcelPackage { get; set; }

        public ExcelPackage CreateExcelPackage<T>(ReportModelBase<T> model, ExcelSetting settings) where T : class, new()
        {
            LoadTemplate(settings.TemplatePath);
            ApplySetting();
            Build(model, settings);
            ClearTemplate();
            return ExcelPackage;
        }

        private void LoadTemplate(string templatePath)
        {
            using (var stream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                statisticSheet = ExcelPackage.Workbook.Worksheets.Copy("Template", "Statistic");
                templateSheet = ExcelPackage.Workbook.Worksheets["Template"];
                totalTemplateSheet = ExcelPackage.Workbook.Worksheets["TotalTemplate"];
            }
        }

        private void ApplySetting()
        {
            statisticSheet.OutLineSummaryBelow = false;
        }

        private void ClearTemplate()
        {
            ExcelPackage.Workbook.Worksheets.Delete(templateSheet);
            ExcelPackage.Workbook.Worksheets.Delete(totalTemplateSheet);
        }

        private void Build<T>(ReportModelBase<T> model, ExcelSetting setting) where T : class, new()
        {
            SetRowIndex(setting.StartRowIndex);
            SetSheetName(setting.SheetName);
            ApplyDescription(setting.Title, setting.TitleCellRange);
            ApplyDescription(setting.Filter, setting.FilterCellRange);
            ApplyBody(model.Entities);
            ApplyFooter(model.Total);
        }

        private void SetRowIndex(int rowIndex)
        {
            RowIndex = rowIndex;
        }

        private void SetSheetName(string sheetName)
        {
            statisticSheet.Name = sheetName;
        }

        private void ApplyDescription(string description, string descriptionCellRange)
        {
            statisticSheet.Cells[descriptionCellRange].Value = description;
        }

        private void ApplyBody<T>(List<T> statistics) where T : class, new()
        {
            statistics.ForEach(s =>
            {
                statisticSheet.ApplyModel(templateSheet, RowIndex, s);
                RowIndex++;
            });
        }

        private void ApplyFooter<T>(T total) where T : class, new()
        {
            statisticSheet.ApplyModel(totalTemplateSheet, RowIndex, total);
            statisticSheet.Cells[$"A{RowIndex}"].Value = "Total";
        }
    }
}
