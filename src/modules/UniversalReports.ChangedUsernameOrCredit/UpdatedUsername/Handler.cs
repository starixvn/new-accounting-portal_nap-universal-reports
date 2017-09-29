using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername
{
    public class Handler : IAsyncRequestHandler<Message, IEnumerable<UpdatedUsernameModel>>
    {
        private readonly UpdatedUsernameService service;

        public Handler(UpdatedUsernameService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<UpdatedUsernameModel>> Handle(Message message)
        {
            return await service.GetUpdatedUsername(message).ConfigureAwait(false);
        }
    }
}
