using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using OfficeOpenXml;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.AssociatedAccount
{
    public class HandlerExcel : IRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly AssociatedFacade associatedFacade;

        private readonly ExcelSettingFactory excelSettingFactory;

        private readonly PunterAnalysisExcelBuilder excelBuilder;

        public HandlerExcel(AssociatedFacade associatedFacade, ExcelSettingFactory excelSettingFactory, PunterAnalysisExcelBuilder excelBuilder)
        {
            this.associatedFacade = associatedFacade;
            this.excelSettingFactory = excelSettingFactory;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel request, CancellationToken cancellationToken)
        {
            var associatedSummaries = await associatedFacade.Query(request).ConfigureAwait(false);

            var excelViewModel = Mapper.Map<SummaryEntity<AssociatedSummaryExcelModel>>(associatedSummaries);
            var excelSettingParams = Mapper.Map<ExcelSettingParams>(request);
            var excelSetting = excelSettingFactory.CreateSetting(excelSettingParams);
            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);
            return excelPackage;
        }
    }
}