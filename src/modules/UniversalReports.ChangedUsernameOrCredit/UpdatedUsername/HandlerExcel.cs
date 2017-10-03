using AutoMapper;
using MediatR;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.UpdatedUsernameAndCredit.Common;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedUsername
{
    public class HandlerExcel : IAsyncRequestHandler<ExcelMessage, ExcelPackage>
    {
        private readonly UpdatedUsernameService service;
        private readonly ExcelSettingFactory excelSettingFactory;
        private readonly ExcelBuilder excelBuilder;

        public HandlerExcel(UpdatedUsernameService service, ExcelSettingFactory excelSettingFactory, ExcelBuilder excelBuilder)
        {
            this.service = service;
            this.excelSettingFactory = excelSettingFactory;
            this.excelBuilder = excelBuilder;
        }

        public async Task<ExcelPackage> Handle(ExcelMessage message)
        {
            var model = await service.GetUpdatedUsername(message).ConfigureAwait(false);

            var excelViewModel = Mapper.Map<IEnumerable<UpdatedUsernameModel>, IEnumerable<UpdatedUsernameExcelModel>>(
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
