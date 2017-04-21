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

        private ExcelWorksheet totalTemplateSheet;

        private int StartRowIndex { get; set; }

        private int EndRowIndex { get; set; }

        private ExcelPackage excelPackage { get; set; }

        public ExcelPackage CreateExcelPackage<T>(ReportModelBase<T> model, ExcelSetting settings) where T : class, new()
        {
            LoadTemplate(settings.TemplatePath);
            ApplySetting();
            Build(model, settings);
            ClearTemplate();
            return excelPackage;
        }

        private void LoadTemplate(string templatePath)
        {
            using (var stream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            {
                excelPackage = new ExcelPackage(stream);
                statisticSheet = excelPackage.Workbook.Worksheets.Copy("Template", "Statistic");
                totalTemplateSheet = excelPackage.Workbook.Worksheets["TotalTemplate"];
            }
        }

        private void ApplySetting()
        {
            statisticSheet.OutLineSummaryBelow = false;
        }

        private void ClearTemplate()
        {
            excelPackage.Workbook.Worksheets.Delete("Template");
            excelPackage.Workbook.Worksheets.Delete(totalTemplateSheet);
        }

        private void Build<T>(ReportModelBase<T> model, ExcelSetting setting) where T : class, new()
        {
            SetStartRowIndex(setting.StartRowIndex);
            SetEndRowIndex(setting.StartRowIndex, model.Entities.Count);
            SetSheetName(setting.SheetName);
            ApplyDescription(setting.Title, setting.TitleCellRange);
            ApplyDescription(setting.Filter, setting.FilterCellRange);
            ApplyBody(model.Entities);
            ApplyFooter(model.Total);
        }

        private void SetStartRowIndex(int startRowIndex)
        {
            StartRowIndex = startRowIndex;
        }

        private void SetEndRowIndex(int startRowIndex, int numberBodyItems)
        {
            EndRowIndex = startRowIndex + numberBodyItems;
        }

        private void SetSheetName(string sheetName)
        {
            statisticSheet.Name = sheetName;
        }

        private void ApplyDescription(string description, string descriptionCellRange)
        {
            statisticSheet.Cells[descriptionCellRange].Value = description;
        }

        private void ApplyBody<T>(IEnumerable<T> statistics) where T : class, new()
        {
            statisticSheet.ApplyVertical(statistics, StartRowIndex);
        }

        private void ApplyFooter<T>(T total) where T : class, new()
        {
            statisticSheet.ApplyModel(totalTemplateSheet, total, EndRowIndex);
            statisticSheet.Cells[$"A{EndRowIndex}"].Value = "Total";
        }
    }
}