using AutoMapper;
using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.UpdatedUsernameAndGivenCredit.Common;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername
{
    public interface UpdatedUsernameService
    {
        UpdatedUsernameModel GetUpdatedUsernameItem(UpdatedUsernameEntity changedUsernameEntity);

        Task<IEnumerable<UpdatedUsernameModel>> GetUpdatedUsername(BaseMessage message);
    }

    public class UpdatedUsernameServiceImp : UpdatedUsernameService
    {
        private readonly IDynamicRepository repository;

        private readonly LogParseService logParseService;

        public UpdatedUsernameServiceImp(IDynamicRepository repository, LogParseService logParseService)
        {
            this.repository = repository;
            this.logParseService = logParseService;
        }

        public async Task<IEnumerable<UpdatedUsernameModel>> GetUpdatedUsername(BaseMessage message)
        {
            var criteria = Mapper.Map<Criteria>(message);

            var rawData = await repository.FetchAsync<UpdatedUsernameEntity>(criteria).ConfigureAwait(false);

            var result = from item in rawData select GetUpdatedUsernameItem(item);


            return result;
        }

        public UpdatedUsernameModel GetUpdatedUsernameItem(UpdatedUsernameEntity updatedUsernameEntity)
        {
            var changedUsernameLog = logParseService.GetUsernameLog(updatedUsernameEntity.TrackingValue);
            var changedUsername = Mapper.Map<UpdatedUsernameModel>(updatedUsernameEntity);
            changedUsername.FromUsername = changedUsernameLog.FromName;
            changedUsername.ToUsername = changedUsernameLog.ToName;

            return changedUsername;
        }
    }
}
