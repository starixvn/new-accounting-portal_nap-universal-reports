using Fanex.Data.Repository;
using Linq.DynamicSum;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public interface BetCountService
    {
        Task<ReportModelBase<BetCountModel>> Query(Criteria criteria);
    }

    public class BetCountServiceImp : BetCountService
    {
        private readonly IDynamicRepository repository;

        private readonly DateTimeService dateTimeService;

        public BetCountServiceImp(IDynamicRepository repository, DateTimeService dateTimeService)
        {
            this.repository = repository;
            this.dateTimeService = dateTimeService;
        }

        public async Task<ReportModelBase<BetCountModel>> Query(Criteria criteria)
        {
            var entities = await repository.FetchAsync<BetCountRawModel>(criteria);
            var entityList = entities.Select(e => Map(e, criteria.PeriodType))
                                    .ToList();

            return new ReportModelBase<BetCountModel>
            {
                Entities = entityList,
                Total = entityList.DynamicSum()
            };
        }

        private BetCountModel Map(BetCountRawModel rawModel, int periodType)
        {
            return new BetCountModel
            {
                BetCount = rawModel.BetCount,
                DrawCount = rawModel.DrawCount,
                WinCount = rawModel.WinCount,
                WinLoss = rawModel.WinLoss,
                Date = FormatDateTimeByPeriodType(periodType, rawModel.Date)
            };
        }

        public string FormatDateTimeByPeriodType(int periodType, DateTime date)
        {
            switch ((PeriodTypeEnum)periodType)
            {
                case PeriodTypeEnum.Daily:
                    return $"{date:yyyy-MM-dd}";

                case PeriodTypeEnum.Weekly:
                    return $"{date:MM/yyyy} - Week {dateTimeService.GetWeekOfYearIso8601(date)}";

                default:
                    return $"{date:MM/yyyy}";
            }
        }
    }
}