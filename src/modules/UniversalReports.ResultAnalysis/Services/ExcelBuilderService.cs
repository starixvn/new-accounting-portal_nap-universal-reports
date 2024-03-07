using Epplus.Mapper.Extensions;
using OfficeOpenXml;
using System.IO;
using System.Linq;
using UniversalReports.Configurations;
using UniversalReports.ResultAnalysis.Models;

namespace UniversalReports.ResultAnalysis.Services
{
	public interface ExcelBuilderService
	{
		ExcelPackage Build(string title, ResultAnalysisExcelModel model, int sportId);
	}

	public class ExcelBuilderServiceImp : ExcelBuilderService
	{
		private readonly ConfigurationService configurationService;

		private ExcelWorksheet sheet;

		private ExcelPackage ExcelPackage { get; set; }

		private const int StartSummaryRowIndex = 6;

		private const int StartDetailedRowIndex = 10;

		private const int Soccer = 1;

		public ExcelBuilderServiceImp(ConfigurationService configurationService)
		{
			this.configurationService = configurationService;
		}

		public ExcelPackage Build(string title, ResultAnalysisExcelModel model, int sportId)
		{
			var isSoccer = sportId == Soccer;
			var fileExcel = isSoccer ? "ResultAnalysis.xlsx" : "SimpleResultAnalysis.xlsx";
			var cellAddressOfTitle = isSoccer ? "A1:P1" : "A1:M1";
			var cellAddressOfBreadCrumb = isSoccer ? "A3:P3" : "A3:M3";
			LoadTemplate(fileExcel);
			BuildTitle(title, cellAddressOfTitle);
			BuildBreadCrumb(title, cellAddressOfBreadCrumb);
			sheet.ApplyModel(sheet, model.Summary, StartSummaryRowIndex);
			sheet.ApplyVertical(model.Items, StartDetailedRowIndex);
			if (!isSoccer)
			{
				this.ResetValueForUnusedCell(model.Items.Count());
			}
			return ExcelPackage;
		}

		private void LoadTemplate(string fileExcel)
		{
			var templateAbsolutelyPath = $"{configurationService.CurrentDirectory}\\ExcelTemplate\\ResultAnalysis\\{fileExcel}";
			using (var stream = new FileStream(templateAbsolutelyPath, FileMode.Open, FileAccess.Read))
			{
				ExcelPackage = new ExcelPackage(stream);
				sheet = ExcelPackage.Workbook.Worksheets["Results"];
			}
		}

		private void BuildTitle(string title, string cellRange)
		{
			sheet.Cells[cellRange].Value = title;
		}

		private void BuildBreadCrumb(string title, string cellRange)
		{
			sheet.Cells[cellRange].Value = title;
		}

		private void ResetValueForUnusedCell(int totalOfDetailedItems)
		{
			sheet.Cells["M6"].Value = sheet.Cells["N6"].Value = sheet.Cells["O6"].Value = sheet.Cells["P6"].Value = "";
			sheet.Cells[$"N10:N{StartDetailedRowIndex + totalOfDetailedItems}"].Value = "";
		}
	}
}
