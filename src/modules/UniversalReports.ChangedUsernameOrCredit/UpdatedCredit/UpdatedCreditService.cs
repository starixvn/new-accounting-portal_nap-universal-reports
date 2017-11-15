using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using UniversalReports.UpdatedUsernameCredit.Common;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedCredit
{
    public interface UpdatedCreditService
    {
        Task<IEnumerable<UpdatedCreditModel>> GetUpdatedCredit(BaseMessage message);
    }

    public class UpdatedCreditServiceImp : UpdatedCreditService
    {
        private readonly IDynamicRepository repository;

        public UpdatedCreditServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<UpdatedCreditModel>> GetUpdatedCredit(BaseMessage message)
        {
            var criteria = Mapper.Map<Criteria>(message);

            var rawData = await repository.FetchAsync<UpdatedCreditEntity>(criteria).ConfigureAwait(false);

            return Mapper.Map<List<UpdatedCreditModel>>(rawData.ToList());
        }
    }
}