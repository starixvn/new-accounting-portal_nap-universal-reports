using Epplus.Mapper.Extensions;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace UniversalReports.PlayForFun.Core
{
    public interface PlayForFunExcelBuilder
    {
        ExcelPackage CreateExcelPackage<T, T1>(
            ReportModelBase<T> summaryExcelModel,
            ExcelSetting summarySetting,
            ReportModelBase<T1> detailExcelModel,
            ExcelSetting detailSetting)
            where T : class, new()
            where T1 : class, new();
    }

    public class PlayForFunExcelBuilderImp : PlayForFunExcelBuilder
    {
        private ExcelWorksheet summarySheet;

        private ExcelWorksheet summaryTemplateSheet;

        private ExcelWorksheet summaryTotalTemplateSheet;

        private ExcelWorksheet detailSheet;

        private ExcelWorksheet detailTemplateSheet;

        private ExcelWorksheet detailTotalTemplateSheet;

        private int RowIndex { get; set; }

        private ExcelPackage ExcelPackage { get; set; }

        public ExcelPackage CreateExcelPackage<T, T1>(
            ReportModelBase<T> summaryExcelModel,
            ExcelSetting summarySetting,
            ReportModelBase<T1> detailExcelModel,
            ExcelSetting detailSetting)
            where T : class, new()
            where T1 : class, new()
        {
            LoadTemplate(summarySetting.TemplatePath);
            ApplySetting();
            Build(summarySheet, summaryTemplateSheet, summaryTotalTemplateSheet, summaryExcelModel, summarySetting);
            Build(detailSheet, detailTemplateSheet, detailTotalTemplateSheet, detailExcelModel, detailSetting);
            ClearTemplate();
            return ExcelPackage;
        }

        private void LoadTemplate(string templatePath)
        {
            using (var stream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                summarySheet = ExcelPackage.Workbook.Worksheets.Copy("SummaryTemplate", "Summary");
                summaryTemplateSheet = ExcelPackage.Workbook.Worksheets["SummaryTemplate"];
                summaryTotalTemplateSheet = ExcelPackage.Workbook.Worksheets["SummaryTotalTemplate"];
                detailSheet = ExcelPackage.Workbook.Worksheets.Copy("ProductStatisticsTemplate", "ProductStatistics");
                detailTemplateSheet = ExcelPackage.Workbook.Worksheets["ProductStatisticsTemplate"];
                detailTotalTemplateSheet = ExcelPackage.Workbook.Worksheets["ProductTotalTemplate"];
            }
        }

        private void ApplySetting()
        {
            summarySheet.OutLineSummaryBelow = false;
            detailSheet.OutLineSummaryBelow = false;
        }

        private void ClearTemplate()
        {
            ExcelPackage.Workbook.Worksheets.Delete(summaryTemplateSheet);
            ExcelPackage.Workbook.Worksheets.Delete(summaryTotalTemplateSheet);
            ExcelPackage.Workbook.Worksheets.Delete(detailTemplateSheet);
            ExcelPackage.Workbook.Worksheets.Delete(detailTotalTemplateSheet);
        }

        private void Build<T>(
            ExcelWorksheet workSheet,
            ExcelWorksheet bodyTemplateSheet,
            ExcelWorksheet totalTemplateSheet,
            ReportModelBase<T> model,
            ExcelSetting setting) where T : class, new()
        {
            SetRowIndex(setting.StartRowIndex);
            SetSheetName(workSheet, setting.SheetName);
            ApplyDescription(workSheet, setting.Title, setting.TitleCellRange);
            ApplyBody(workSheet, bodyTemplateSheet, model.Entities);
            ApplyFooter(workSheet, totalTemplateSheet, model.Total);
            workSheet.AutoMergeRowsHaveSameValue(new ExcelAddress($"A{setting.StartRowIndex}:A{RowIndex}"));
        }

        private void SetRowIndex(int rowIndex)
        {
            RowIndex = rowIndex;
        }

        private void SetSheetName(ExcelWorksheet workSheet, string sheetName)
        {
            workSheet.Name = sheetName;
        }

        private void ApplyDescription(ExcelWorksheet workSheet, string description, string descriptionCellRange)
        {
            workSheet.Cells[descriptionCellRange].Value = description;
        }

        private void ApplyBody<T>(ExcelWorksheet workSheet, ExcelWorksheet templateSheet, List<T> statistics) where T : class, new()
        {
            statistics.ForEach(s =>
            {
                workSheet.ApplyModel(templateSheet, RowIndex, s);
                RowIndex++;
            });
        }

        private void ApplyFooter<T>(ExcelWorksheet workSheet, ExcelWorksheet totalTemplateSheet, T total) where T : class, new()
        {
            workSheet.ApplyModel(totalTemplateSheet, RowIndex, total);
            workSheet.Cells[$"A{RowIndex}"].Value = "Total";
        }
    }
}
