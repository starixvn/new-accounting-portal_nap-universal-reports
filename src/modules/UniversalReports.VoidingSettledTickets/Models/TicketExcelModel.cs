using Epplus.Mapper.Annotations;
using System;

namespace UniversalReports.VoidingSettledTickets.Models
{
    public class TicketExcelModel
    {
        private string voidedTime;

        [Cell("A4")]
        public string TransId { get; set; }

        [Cell("B4")]
        public string Username { get; set; }

        [Cell("C4")]
        public int MatchId { get; set; }

        [Cell("D4")]
        public string VoidedTime
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(voidedTime))
                {
                    var date = DateTime.Parse(voidedTime);
                    return date.ToString("MMM dd, yyyy, hh:mm:ss tt");
                }

                return voidedTime;
            }
            set
            {
                voidedTime = value;
            }
        }

        [Cell("E4")]
        public decimal HouseIncomeBeforeExtraPT { get; set; }

        [Cell("F4")]
        public decimal HouseIncomeAfterExtraPT { get; set; }
    }
}