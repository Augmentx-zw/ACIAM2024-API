using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.PaymentDetails
{
    public class GetPaymentsQuery : IQuery<IEnumerable<Payment>>
    {
    }

    public class GetPaymentsQueryHandler : IQueryHandler<GetPaymentsQuery, IEnumerable<Payment>>
    {
        private readonly IRepository<Payment> _repo;

        public GetPaymentsQueryHandler(IRepository<Payment> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Payment> Handle(GetPaymentsQuery query)
        {
            return _repo.Get();
        }
    }
}
