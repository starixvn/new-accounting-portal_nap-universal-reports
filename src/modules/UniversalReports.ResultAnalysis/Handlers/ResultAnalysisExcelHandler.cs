using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.ResultAnalysis.Criteria;
using UniversalReports.ResultAnalysis.Models;
using UniversalReports.ResultAnalysis.Requests;
using UniversalReports.ResultAnalysis.Services;

namespace UniversalReports.ResultAnalysis.Handlers
{
	public class ResultAnalysisExcelHandler: IRequestHandler<ResultAnalysisExcelRequest, ExcelPackage>
	{
		private readonly ResultAnalysisService service;
		private readonly ExcelBuilderService excelService;

		public ResultAnalysisExcelHandler(ResultAnalysisService service, ExcelBuilderService excelService)
		{
			this.service = service;
			this.excelService = excelService;
		}

		public async Task<ExcelPackage> Handle(ResultAnalysisExcelRequest request, CancellationToken cancellationToken)
		{
			var criteria = Mapper.Map<ResultAnalysisCriteria>(request);
			var data = await service.GetResultAnalysis(criteria);
			var excelModel = Mapper.Map<ResultAnalysisExcelModel>(data);
			var title = $"Result Analysis Report From {criteria.FromDate:MMM dd, yyyy} To {criteria.ToDate:MMM dd, yyyy}";
			return excelService.Build(title, excelModel, request.SportId);
		}
	}
}
