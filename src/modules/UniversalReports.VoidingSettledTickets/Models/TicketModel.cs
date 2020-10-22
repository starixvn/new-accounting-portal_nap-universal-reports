using System;

namespace UniversalReports.VoidingSettledTickets.Models
{
    public class TicketModel
    {
        public Int64 TransId { get; set; }

        public string Username { get; set; }

        public int MatchId { get; set; }

        public string VoidedTime { get; set; }

        public decimal HouseIncomeBeforeExtraPT { get; set; }

        public decimal HouseIncomeAfterExtraPT { get; set; }

        public static TicketModel operator +(TicketModel a, TicketModel b)
        {
            return new TicketModel
            {
                HouseIncomeBeforeExtraPT = a.HouseIncomeBeforeExtraPT + b.HouseIncomeBeforeExtraPT,
                HouseIncomeAfterExtraPT = a.HouseIncomeAfterExtraPT + b.HouseIncomeAfterExtraPT,
            };
        }
    }
}