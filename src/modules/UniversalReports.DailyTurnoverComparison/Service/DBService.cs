using Fanex.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.DailyTurnoverComparison.Criterias;
using UniversalReports.DailyTurnoverComparison.Model;

namespace UniversalReports.DailyTurnoverComparison.Service
{
    public interface DBService
    {
        List<TurnoverModel> Query(DateTime toDate, int topLicensees);

        TaskstatusModel QueryDWStatus();
    }

    public class DBServiceImp : DBService
    {
        private readonly IDynamicRepository repository;

        public DBServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public List<TurnoverModel> Query(DateTime toDate, int topLicensees)
        {
            var criteria = new Criteria
            {
                ToDate = toDate,
                Top = topLicensees
            };

            return repository.Fetch<TurnoverModel>(criteria).ToList();
        }

        public TaskstatusModel QueryDWStatus()
        {
            return repository.Get<TaskstatusModel>(new GetDWStatusCriteria { TaskIDList = "53" });
        }
    }
}