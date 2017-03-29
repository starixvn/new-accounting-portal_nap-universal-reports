using Fanex.Data.Repository;
using System;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.League
{
    public interface LeagueServiceFactory
    {
        LeagueService CreateLeagueService(int periodType);
    }

    public class LeagueServiceFactoryImp : LeagueServiceFactory
    {
        private readonly IDynamicRepository repository;

        public LeagueServiceFactoryImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public LeagueService CreateLeagueService(int periodType)
        {
            var dateTimeService = new DateTimeServiceImp();
            var periodTypeEnum = (PeriodTypeEnum)periodType;

            switch (periodTypeEnum)
            {
                case PeriodTypeEnum.Weekly:
                    return new LeagueServiceByWeek(repository, dateTimeService);
                case PeriodTypeEnum.Annually:
                case PeriodTypeEnum.Daily:
                case PeriodTypeEnum.Monthly:
                case PeriodTypeEnum.MonthRange:
                    return new LeagueServiceByMonth(repository);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
