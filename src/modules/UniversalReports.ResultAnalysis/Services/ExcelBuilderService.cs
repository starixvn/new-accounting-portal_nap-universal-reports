using OfficeOpenXml;
using System;
using UniversalReports.ResultAnalysis.Models;

namespace UniversalReports.ResultAnalysis.Services
{
	public interface ExcelBuilderService
	{
		ExcelPackage Build(string title, ResultAnalysisExcelModel model);
	}

	public class ExcelBuilderServiceImp : ExcelBuilderService
	{
		public ExcelPackage Build(string title, ResultAnalysisExcelModel model)
		{
			throw new NotImplementedException();
		}
	}
}
