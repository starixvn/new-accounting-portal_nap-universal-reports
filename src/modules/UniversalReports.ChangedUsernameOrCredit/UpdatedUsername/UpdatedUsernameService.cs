using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fanex.Data.Repository;
using UniversalReports.UpdatedUsernameCredit.Common;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedUsername
{
    public interface UpdatedUsernameService
    {
        Task<List<UpdatedUsernameModel>> GetUpdatedUsername(BaseMessage message);
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

        public async Task<List<UpdatedUsernameModel>> GetUpdatedUsername(BaseMessage message)
        {
            var criteria = Mapper.Map<Criteria>(message);

            var rawData = await repository.FetchAsync<UpdatedUsernameEntity>(criteria);

            var result = rawData.Select(GetUpdatedUsernameItem).ToList();

            return result;
        }

        public UpdatedUsernameModel GetUpdatedUsernameItem(UpdatedUsernameEntity updatedUsernameEntity)
        {
            var updatedUsernameLog = logParseService.GetUsernameLog(updatedUsernameEntity.TrackingValue);
            var updatedUsername = Mapper.Map<UpdatedUsernameModel>(updatedUsernameEntity);
            updatedUsername.FromUsername = updatedUsernameLog.FromName;
            updatedUsername.ToUsername = updatedUsernameLog.ToName;

            return updatedUsername;
        }
    }
}