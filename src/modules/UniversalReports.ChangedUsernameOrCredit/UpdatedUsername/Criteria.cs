using Fanex.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername
{
    public class Criteria : CriteriaBase
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Username { get; set; }

        public override bool IsValid() => FromDate <= ToDate;

        public override string GetSettingKey() => "Acc_Rpt_AdminUpdateUserName";
    }
}
