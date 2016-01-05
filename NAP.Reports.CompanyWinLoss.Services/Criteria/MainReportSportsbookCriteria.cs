using Fanex.Data.Repository;
using System;

namespace NAP.Reports.CompanyWinLoss.Services.Criteria
{
    class MainReportSportsbookCriteria : CriteriaBase
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string GetSettingKey()
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            return true;
        }
    }
}
