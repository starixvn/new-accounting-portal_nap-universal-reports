using System.Collections.Generic;
using System.IO;
using Epplus.Mapper.Extensions;
using Linq.DynamicSum;
using OfficeOpenXml;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Summary
{
    public interface ExcelBuilder
    {
        ExcelPackage CreateExcelPackage<T, T1>(
            SummaryEntity<T> summaryExcelModel,
            ExcelSetting summarySetting,
            SummaryEntity<T1> detailExcelModel,
            ExcelSetting detailSetting)
            where T : class, new()
            where T1 : class, new();
    }

    public class ExcelBuilderImp : ExcelBuilder
    {
        private ExcelWorksheet summarySheet;

        private ExcelWorksheet summaryTotalTemplateSheet;

        private ExcelWorksheet detailSheet;

        private ExcelWorksheet detailTotalTemplateSheet;

        private int StartRowIndex { get; set; }

        private int EndRowIndex { get; set; }

        private ExcelPackage ExcelPackage { get; set; }

        public ExcelPackage CreateExcelPackage<T, T1>(
            SummaryEntity<T> summaryExcelModel,
            ExcelSetting summarySetting,
            SummaryEntity<T1> detailExcelModel,
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
            SummaryEntity<T> model,
            ExcelSetting setting) where T : class, new()
        {
            SetStartRowIndex(setting.StartRowIndex);
            SetEndRowIndex(setting.StartRowIndex, model.Entities.Count);
            SetSheetName(workSheet, setting.SheetName);
            ApplyDescription(workSheet, setting.Title, setting.TitleCellRange);
            ApplyBody(workSheet, model.Entities);
            ApplyFooter(workSheet, totalTemplateSheet, model.Total, setting.MergedColumnCountOfTotalRow);
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

        private static void SetSheetName(ExcelWorksheet workSheet, string sheetName)
        {
            workSheet.Name = sheetName;
        }

        private static void ApplyDescription(ExcelWorksheet workSheet, string description, string descriptionCellRange)
        {
            workSheet.Cells[descriptionCellRange].Value = description;
        }

        private void ApplyBody<T>(ExcelWorksheet workSheet, IEnumerable<T> statistics) where T : class, new()
        {
            workSheet.ApplyVertical(statistics, StartRowIndex);
        }

        private void ApplyFooter<T>(ExcelWorksheet workSheet, ExcelWorksheet totalTemplateSheet, T total, int mergedColumnCountOfTotalRow) where T : class, new()
        {
            workSheet.ApplyModel(totalTemplateSheet, total, EndRowIndex);

            var cellAddressOfTotalText = new ExcelAddressBase(EndRowIndex, 1, EndRowIndex, mergedColumnCountOfTotalRow);

            workSheet.Cells[cellAddressOfTotalText.Address].Value = "Total";
            workSheet.Cells[cellAddressOfTotalText.Address].Merge = true;
        }
    }
}