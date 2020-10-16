using AutoMapper;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.VoidingSettledTickets.Criteria;
using UniversalReports.VoidingSettledTickets.Models;
using UniversalReports.VoidingSettledTickets.Requests;

namespace UniversalReports.VoidingSettledTickets.Services
{
    public interface VoidingSettledService
    {
        Task<SummaryEntity<ProductModel>> GetProducts(ProductRequest request);

        Task<VoidTicketModel> GetTickets(TicketRequest request);
    }

    public class VoidingSettledServiceImp : VoidingSettledService
    {
        private readonly IDynamicRepository repository;

        public VoidingSettledServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SummaryEntity<ProductModel>> GetProducts(ProductRequest request)
        {
            var criteria = Mapper.Map<ProductCriteria>(request);
            return (await repository.FetchAsync<ProductModel>(criteria)).CalculateSummaryEntity();
        }

        public async Task<VoidTicketModel> GetTickets(TicketRequest request)
        {
            var criteria = Mapper.Map<TicketCriteria>(request);

            var data = await repository.FetchMultipleAsync<TicketModel, int>(criteria);
            var tickets = data.Item1.CalculateSummaryEntity();

            return new VoidTicketModel
            {
                Tickets = tickets.Entities,
                Total = tickets.Total,
                TotalItems = data.Item2.FirstOrDefault()
            };
        }
    }
}