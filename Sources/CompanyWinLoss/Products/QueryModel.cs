using System;
using UniversalReports.MVC.Validation;

namespace UniversalReports.CompanyWinLoss.Products
{
    public class ProductWinLossQuery
    {
        public DateTime StartDate { get; set; }

        [DateTimeGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }
    }
}
