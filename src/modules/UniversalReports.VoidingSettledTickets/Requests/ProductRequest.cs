using Linq.DynamicSum;
using MediatR;
using System;
using UniversalReports.VoidingSettledTickets.Models;

namespace UniversalReports.VoidingSettledTickets.Requests
{
    public class ProductRequest : IRequest<SummaryEntity<ProductModel>>
    {
        public DateTime WinlostDate { get; set; }

        public int? MatchId { get; set; }

        public DateTime? VoidTime { get; set; }
    }
}