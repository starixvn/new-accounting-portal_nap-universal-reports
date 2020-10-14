using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.Report
{
    public class ReportHandlerExcel : IRequestHandler<LicenseeHttpParameterExcel, ExcelPackage>,
        IRequestHandler<MemberHttpParameterExcel, ExcelPackage>
    {
        private readonly ReportService service;

        private ReportExcelBuilder excelBuilder;

        public ReportHandlerExcel(ReportService service, ReportExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(MemberHttpParameterExcel request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<MemberQueryCriteria>(request);
            var memberModel = await service.QueryMember(criteria);
            var memberExcelModel = Mapper.Map<IEnumerable<MemberExcelModel>>(memberModel.Members);
            var excelPackage = excelBuilder.Build(request.Title, memberExcelModel);
            return excelPackage;
        }

        public async Task<ExcelPackage> Handle(LicenseeHttpParameterExcel request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<LicenseeQueryCriteria>(request);
            var licenseeModel = await service.QueryLicensee(criteria);
            var licenseeExcelModel = Mapper.Map<IEnumerable<LicenseeExcelModel>>(licenseeModel.Licensees);
            var excelPackage = excelBuilder.Build(request.Title, licenseeExcelModel);
            return excelPackage;
        }
    }
}