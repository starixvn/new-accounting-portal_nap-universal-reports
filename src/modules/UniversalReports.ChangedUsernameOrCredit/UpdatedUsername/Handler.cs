using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return await service.GetChangedUsername(message).ConfigureAwait(false);
        }
    }
}
