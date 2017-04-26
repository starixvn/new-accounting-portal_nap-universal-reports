using Fanex.Data.Repository;
using System;

namespace UniversalReports.PlayForFun.Summary.Model
{
    public class SummaryCriteria : CriteriaBase
    {
        public string Username { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int ProductId { get; set; }

        public int StatusId { get; set; }

        public bool ExcludeTest { get; set; }

        public override string GetSettingKey() => "PlayForFun-Summary";

        public override bool IsValid() => true;
    }
}