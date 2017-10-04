using System;
using Fanex.Data.Repository;

namespace UniversalReports.PlayForFun.Detail.Model
{
    public class DetailCriteria : CriteriaBase
    {
        public string Username { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int ProductId { get; set; }

        public int StatusId { get; set; }

        public bool ExcludeTest { get; set; }

        public override string GetSettingKey() => "PlayForFun-Detail";

        public override bool IsValid() => true;
    }
}