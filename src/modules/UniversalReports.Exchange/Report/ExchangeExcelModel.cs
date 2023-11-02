using Linq.DynamicSum;
using System.Collections.Generic;

namespace UniversalReports.Exchange.Report
{
    public class ExchangeExcelModel
    {
        public IEnumerable<SummaryEntity<ExchangeExcelEntity>> ExchangeLicensees { get; set; }

        public ExchangeExcelEntity GrandTotal { get; set; }

        public IEnumerable<ExchangeExcelEntity> MarketTypeTotal { get; set; }
    }
}
