using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.League.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.League
{
    public class HandlerExcel : IAsyncRequestHandler<HttpParameterExcel, ExcelPackage>
    {
        private readonly IMapper mapper;

        private readonly PunterAnalysisService punterAnalysisService;

        public HandlerExcel(IMapper mapper, PunterAnalysisService punterAnalysisService)
        {
            this.mapper = mapper;
            this.punterAnalysisService = punterAnalysisService;
        }

        public async Task<ExcelPackage> Handle(HttpParameterExcel message)
        {
            throw new NotImplementedException();
        }
    }
}
