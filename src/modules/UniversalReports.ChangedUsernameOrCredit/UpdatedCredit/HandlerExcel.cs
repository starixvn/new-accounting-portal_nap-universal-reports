using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeOpenXml;
using UniversalReports.UpdatedUsernameAndCredit.Common;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedCredit
{
    public class HandlerExcel : IAsyncRequestHandler<ExcelMessage, ExcelPackage>
    {
        private readonly UpdatedCreditService service;
        private readonly ExcelSettingFactory excelSettingFactory;
        private readonly ExcelBuilder excelBuilder;

        public HandlerExcel(UpdatedCreditService service, ExcelSettingFactory excelSettingFactory, ExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelSettingFactory = excelSettingFactory;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(ExcelMessage message)
        {
            var model = await service.GetUpdatedCredit(message).ConfigureAwait(false);

            var excelViewModel = Mapper.Map<IEnumerable<UpdatedCreditModel>, IEnumerable<UpdatedCreditExcelModel>>(
                model,
                option =>
                   {
                       option.AfterMap((source, destination) =>
                       {
                           int index = 0;
                           foreach (var item in destination)
                           {
                               item.Index = index + 1;
                               index++;
                           }
                       });
                   });

            var excelSetting = excelSettingFactory.CreateSetting(message);

            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);

            return excelPackage;
        }
    }
}