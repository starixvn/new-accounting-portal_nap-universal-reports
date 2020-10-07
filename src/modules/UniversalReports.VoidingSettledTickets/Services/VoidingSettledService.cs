using AutoMapper;
using Fanex.Data.Repository;
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
        Task<List<ProductModel>> GetProducts(ProductRequest request);

        Task<List<TicketModel>> GetTickets(TicketRequest request);
    }

    public class VoidingSettledServiceImp : VoidingSettledService
    {
        private readonly IDynamicRepository repository;

        public VoidingSettledServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ProductModel>> GetProducts(ProductRequest request)
        {
            var criteria = Mapper.Map<ProductCriteria>(request);
            var products = await repository.FetchAsync<ProductModel>(criteria);
            return products.ToList();
        }

        public async Task<List<TicketModel>> GetTickets(TicketRequest request)
        {
            var criteria = Mapper.Map<TicketCriteria>(request);
            var tickets = await repository.FetchAsync<TicketModel>(criteria);
            return tickets.ToList();
        }
    }
}