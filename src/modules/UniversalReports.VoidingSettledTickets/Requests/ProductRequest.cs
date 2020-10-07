using MediatR;
using System;
using System.Collections.Generic;
using UniversalReports.VoidingSettledTickets.Models;

namespace UniversalReports.VoidingSettledTickets.Requests
{
    public class ProductRequest : IRequest<List<ProductModel>>
    {
        public DateTime WinlostDate { get; set; }

        public int MatchId { get; set; }

        public DateTime VoidTime { get; set; }
    }
}