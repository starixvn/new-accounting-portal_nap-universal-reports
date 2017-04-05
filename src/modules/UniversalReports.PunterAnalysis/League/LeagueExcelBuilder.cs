using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    public interface LeagueExcelBuilder
    {
        Task<ExcelPackage> CreateExcelPackage(ReportModel model, ExcelSetting setting);
    }

    public class LeagueExcelBuilderImp : LeagueExcelBuilder
    {
        private ExcelWorksheet statisticSheet;

        private ExcelWorksheet templateSheet;

        private ExcelWorksheet headerTemplateSheet;

        private ExcelWorksheet totalTemplateSheet;

        private int RowIndex { get; set; }

        private ExcelPackage ExcelPackage { get; set; }

        public async Task<ExcelPackage> CreateExcelPackage(ReportModel model, ExcelSetting setting)
        {
            LoadTemplate(setting.TemplatePath);
            ApplySetting();
            SetRowIndex(setting.StartRowIndex);
            ApplyDescription(setting.Title, setting.TitleCellRange);
            ApplyDescription(setting.Filter, setting.FilterCellRange);
            CreateHeader(model.GroupNames);
            CreateBody(model.Entities);
            CreateFooter(model.Total);
            ClearTemplate();
            return await Task.FromResult(ExcelPackage);
        }

        private void LoadTemplate(string templatePath)
        {
            using (var stream = new FileStream(templatePath, FileMode.Open, FileAccess.Read))
            {
                ExcelPackage = new ExcelPackage(stream);
                statisticSheet = ExcelPackage.Workbook.Worksheets.Add("Punter Analysis");
                templateSheet = ExcelPackage.Workbook.Worksheets["Template"];
                headerTemplateSheet = ExcelPackage.Workbook.Worksheets["HeaderTemplate"];
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
            ExcelPackage.Workbook.Worksheets.Delete(headerTemplateSheet);
            ExcelPackage.Workbook.Worksheets.Delete(totalTemplateSheet);
        }

        private void SetRowIndex(int rowIndex)
        {
            this.RowIndex = rowIndex;
        }

        private void ApplyDescription(string description, string descriptionCellRange)
        {
            statisticSheet.Cells[descriptionCellRange].Value = description;
        }

        private void CreateHeader(List<string> groupNames)
        {
            int columnIndex = 1;
            statisticSheet.Cells["A7:A8"].Value = "League";
            groupNames.ForEach(groupName =>
            {
                headerTemplateSheet.Cells["A1:D1"].Copy(statisticSheet.Cells[RowIndex, columnIndex, RowIndex, columnIndex + 3]);
                statisticSheet.Cells[RowIndex, columnIndex, RowIndex, columnIndex + 3].Value = groupName;
                statisticSheet.Cells[RowIndex, columnIndex, RowIndex, columnIndex + 3].Merge = true;
                headerTemplateSheet.Cells["A2:D2"].Copy(statisticSheet.Cells[RowIndex + 1, columnIndex, RowIndex + 1, columnIndex + 3]);
                columnIndex += 4;
            });

            RowIndex++;
        }

        private void CreateBody(List<LeagueModel> model)
        {
            model.ForEach(league =>
            {
                int columnIndex = 1;
                statisticSheet.Cells[$"A{RowIndex}"].Value = league.LeagueName;
                league.PeriodGroups.ForEach(group =>
                {
                    templateSheet.Cells["A1:D1"].Copy(statisticSheet.Cells[RowIndex, columnIndex, RowIndex, columnIndex + 3]);
                    MappGroupValue(group, columnIndex);
                    columnIndex += 4;
                });

                RowIndex++;
            });
        }

        private void CreateFooter(LeagueModel model)
        {
            int columnIndex = 1;
            statisticSheet.Cells[$"A{RowIndex}"].Value = "Grand Total";
            model.PeriodGroups.ForEach(group =>
            {
                totalTemplateSheet.Cells["A1:D1"].Copy(statisticSheet.Cells[RowIndex, columnIndex, RowIndex, columnIndex + 3]);
                MappGroupValue(group, columnIndex);
                columnIndex += 4;
            });
        }

        private void MappGroupValue(PeriodGroup group, int columnIndex)
        {
            statisticSheet.Cells[RowIndex, columnIndex].Value = group.WinLoss;
            statisticSheet.Cells[RowIndex, columnIndex + 1].Value = group.Turnover;
            statisticSheet.Cells[RowIndex, columnIndex + 2].Value = group.Margin;
            statisticSheet.Cells[RowIndex, columnIndex + 3].Value = group.BetCount;
        }
    }
}
