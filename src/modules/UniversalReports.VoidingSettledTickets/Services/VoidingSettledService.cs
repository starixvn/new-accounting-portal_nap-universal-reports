using Fanex.Data.Repository;
using Linq.DynamicSum;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.VoidingSettledTickets.Models;

namespace UniversalReports.VoidingSettledTickets.Services
{
    public interface VoidingSettledService
    {
        Task<SummaryEntity<T>> GetProducts<T>(ICriteria criteria) where T : class, new();

        Task<VoidTicketModel> GetTickets(ICriteria criteria);
    }

    public class VoidingSettledServiceImp : VoidingSettledService
    {
        private readonly IDynamicRepository repository;

        public VoidingSettledServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SummaryEntity<T>> GetProducts<T>(ICriteria criteria) where T : class, new()
        {
            return (await repository.FetchAsync<T>(criteria))
                    .CalculateSummaryEntity();
        }

        public async Task<VoidTicketModel> GetTickets(ICriteria criteria)
        {
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