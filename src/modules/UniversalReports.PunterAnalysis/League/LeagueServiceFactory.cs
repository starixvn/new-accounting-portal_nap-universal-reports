using System;
using Fanex.Data.Repository;
using UniversalReports.PunterAnalysis.Shared;

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
            var periodTypeEnum = (PeriodType)periodType;

            switch (periodTypeEnum)
            {
                case PeriodType.Weekly:
                    return new LeagueServiceByWeek(repository, dateTimeService);

                case PeriodType.Annually:
                case PeriodType.Daily:
                case PeriodType.Monthly:
                case PeriodType.MonthRange:
                    return new LeagueServiceByMonth(repository);

                default:
                    throw new NotImplementedException();
            }
        }
    }
}