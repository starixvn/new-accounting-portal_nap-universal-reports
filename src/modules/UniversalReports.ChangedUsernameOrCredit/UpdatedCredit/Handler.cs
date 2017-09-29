using MediatR;
using System.Collections.Generic;
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
            return await service.GetUpdatedCredit(message).ConfigureAwait(false);
        }
    }
}
