using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OfficeOpenXml;
using UniversalReports.UpdatedUsernameCredit.Common;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedUsername
{
    public class HandlerExcel : IRequestHandler<ExcelMessage, ExcelPackage>
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

        public async Task<ExcelPackage> Handle(ExcelMessage request, CancellationToken cancellationToken)
        {
            var model = await service.GetUpdatedUsername(request);

            var excelViewModel = Mapper.Map<IEnumerable<UpdatedUsernameModel>, List<UpdatedUsernameExcelModel>>(
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

            var excelSetting = excelSettingFactory.CreateSetting(request);

            var excelPackage = excelBuilder.CreateExcelPackage(excelViewModel, excelSetting);

            return excelPackage;
        }
    }
}