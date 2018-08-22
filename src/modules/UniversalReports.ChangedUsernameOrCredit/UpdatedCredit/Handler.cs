using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedCredit
{
    public class Handler : IRequestHandler<Message, IEnumerable<UpdatedCreditModel>>
    {
        private readonly UpdatedCreditService service;

        public Handler(UpdatedCreditService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<UpdatedCreditModel>> Handle(Message request, CancellationToken cancellationToken)
        {
            return await service.GetUpdatedCredit(request).ConfigureAwait(false);
        }
    }
}