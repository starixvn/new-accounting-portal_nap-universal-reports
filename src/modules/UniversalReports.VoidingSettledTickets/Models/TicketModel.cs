using System;

namespace UniversalReports.VoidingSettledTickets.Models
{
    public class TicketModel
    {
        public int TransId { get; set; }

        public string Username { get; set; }

        public int MatchId { get; set; }

        public DateTime VoidedTime { get; set; }

        public decimal BeforeExtraPT { get; set; }

        public decimal AfterExtraPT { get; set; }
    }
}