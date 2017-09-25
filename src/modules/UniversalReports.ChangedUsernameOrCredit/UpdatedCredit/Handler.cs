using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedCredit
{
    public class Handler : IAsyncRequestHandler<Message, IEnumerable<UpdatedCreditModel>>
    {
        private readonly UpdatedCreditService service;

        public Handler(UpdatedCreditService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<UpdatedCreditModel>> Handle(Message message)
        {
            return await service.GetChangedCredit(message).ConfigureAwait(false);
        }
    }
}
