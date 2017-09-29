using AutoMapper;
using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.UpdatedUsernameAndGivenCredit.Common;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedCredit
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

            var result = Mapper.Map<IEnumerable<UpdatedCreditModel>>(rawData);

            return result;
        }
    }
}
