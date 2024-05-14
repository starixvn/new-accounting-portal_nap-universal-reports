using SimpleInjector;
using UniversalReports.ResultAnalysis.Services;

namespace UniversalReports.Sites.App_Start.SimpleInjector
{
	internal static class ResultAnalysisInjector
	{
		internal static Container RegisterResultAnalysisServices(this Container container)
		{
			container.Register<ResultAnalysisService, ResultAnalysisServiceImp>();
			container.Register<ExcelBuilderService, ExcelBuilderServiceImp>();
			return container;
		}
	}
}