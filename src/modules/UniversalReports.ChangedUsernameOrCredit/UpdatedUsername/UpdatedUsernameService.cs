using AutoMapper;
using Fanex.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername
{
    public interface UpdatedUsernameService
    {
        UpdatedUsernameModel GetChangeUsernameItem(UpdatedUsernameEntity changedUsernameEntity);

        Task<IEnumerable<UpdatedUsernameModel>> GetChangedUsername(Message message);
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

        public async Task<IEnumerable<UpdatedUsernameModel>> GetChangedUsername(Message message)
        {
            var criteria = Mapper.Map<Criteria>(message);

            var rawData = await repository.FetchAsync<UpdatedUsernameEntity>(criteria).ConfigureAwait(false);

            var result = from item in rawData select GetChangeUsernameItem(item);
       

            return result;
        }

        public UpdatedUsernameModel GetChangeUsernameItem(UpdatedUsernameEntity updatedUsernameEntity)
        {
            var changedUsernameLog = logParseService.GetUsernameLog(updatedUsernameEntity.TrackingValue);
            var changedUsername = Mapper.Map<UpdatedUsernameModel>(updatedUsernameEntity);
            changedUsername.FromUsername = changedUsernameLog.FromName;
            changedUsername.ToUsername = changedUsernameLog.ToName;

            return changedUsername;
        }
    }
}
