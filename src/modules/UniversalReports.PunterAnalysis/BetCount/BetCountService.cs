using System;
using System.Linq;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.BetCount
{
    public interface BetCountService
    {
        Task<SummaryEntity<BetCountModel>> Query(Criteria criteria);
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

        public async Task<SummaryEntity<BetCountModel>> Query(Criteria criteria)
        {
            return (await repository.FetchAsync<BetCountRawModel>(criteria).ConfigureAwait(false))
                           .Select(e => Map(e, criteria.PeriodType))
                           .CalculateSummaryEntity();
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
            switch ((PeriodType)periodType)
            {
                case PeriodType.Daily:
                    return $"{date:yyyy-MM-dd}";

                case PeriodType.Weekly:
                    return $"{date:MM/yyyy} - Week {dateTimeService.GetWeekOfYearIso8601(date)}";

                default:
                    return $"{date:MM/yyyy}";
            }
        }
    }
}