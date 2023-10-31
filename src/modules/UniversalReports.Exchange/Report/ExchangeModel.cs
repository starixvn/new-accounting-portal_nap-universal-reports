using Linq.DynamicSum;
using System.Collections.Generic;

namespace UniversalReports.Exchange.Report
{
    public class ExchangeModel
    {
        public IEnumerable<SummaryEntity<ExchangeItemModel>> ExchangeLicensees { get; set; }

        public ExchangeItemModel GrandTotal { get; set; }

        public IEnumerable<ExchangeItemModel> MarketTypeTotal { get; set; }

        public int TotalItems { get; set; }
    }
}
