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

        private ExcelWorksheet summaryTotalTemplateSheet;

        private ExcelWorksheet detailSheet;

        private ExcelWorksheet detailTotalTemplateSheet;

        private int StartRowIndex { get; set; }

        private int EndRowIndex { get; set; }

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
            Build(summarySheet, summaryTotalTemplateSheet, summaryExcelModel, summarySetting);
            Build(detailSheet, detailTotalTemplateSheet, detailExcelModel, detailSetting);
            ClearTemplate();
            return ExcelPackage;
        }

        private void LoadTemplate(string templatePath)
        {
            using (var stream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                summarySheet = ExcelPackage.Workbook.Worksheets.Copy("SummaryTemplate", "Summary");
                summaryTotalTemplateSheet = ExcelPackage.Workbook.Worksheets["SummaryTotalTemplate"];
                detailSheet = ExcelPackage.Workbook.Worksheets.Copy("ProductStatisticsTemplate", "ProductStatistics");
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
            ExcelPackage.Workbook.Worksheets.Delete("SummaryTemplate");
            ExcelPackage.Workbook.Worksheets.Delete(summaryTotalTemplateSheet);
            ExcelPackage.Workbook.Worksheets.Delete("ProductStatisticsTemplate");
            ExcelPackage.Workbook.Worksheets.Delete(detailTotalTemplateSheet);
        }

        private void Build<T>(
            ExcelWorksheet workSheet,
            ExcelWorksheet totalTemplateSheet,
            ReportModelBase<T> model,
            ExcelSetting setting) where T : class, new()
        {
            SetStartRowIndex(setting.StartRowIndex);
            SetEndRowIndex(setting.StartRowIndex, model.Entities.Count);
            SetSheetName(workSheet, setting.SheetName);
            ApplyDescription(workSheet, setting.Title, setting.TitleCellRange);
            ApplyBody(workSheet, model.Entities);
            ApplyFooter(workSheet, totalTemplateSheet, model.Total);
            workSheet.AutoMergeRowsHaveSameValue($"A{StartRowIndex}:A{EndRowIndex}");
        }

        private void SetStartRowIndex(int startRowIndex)
        {
            StartRowIndex = startRowIndex;
        }

        private void SetEndRowIndex(int startRowIndex, int numberBodyItems)
        {
            EndRowIndex = startRowIndex + numberBodyItems;
        }

        private void SetSheetName(ExcelWorksheet workSheet, string sheetName)
        {
            workSheet.Name = sheetName;
        }

        private void ApplyDescription(ExcelWorksheet workSheet, string description, string descriptionCellRange)
        {
            workSheet.Cells[descriptionCellRange].Value = description;
        }

        private void ApplyBody<T>(ExcelWorksheet workSheet, List<T> statistics) where T : class, new()
        {
            workSheet.ApplyVertical(statistics, StartRowIndex);
        }

        private void ApplyFooter<T>(ExcelWorksheet workSheet, ExcelWorksheet totalTemplateSheet, T total) where T : class, new()
        {
            workSheet.ApplyModel(totalTemplateSheet, total, EndRowIndex);
            workSheet.Cells[$"A{EndRowIndex}"].Value = "Total";
        }
    }
}
