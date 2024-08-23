using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.PaymentDetails
{
    public class GetPaymentByRegistrationDetailIdQuery : IQuery<IEnumerable<Payment>>
    {
        public Guid RegistrationId { get; set; }
    }

    public class GetPaymentByRegistrationDetailIdQueryHandler : IQueryHandler<GetPaymentByRegistrationDetailIdQuery, IEnumerable<Payment>>
    {
        private readonly IRepository<Payment> _repo;

        public GetPaymentByRegistrationDetailIdQueryHandler(IRepository<Payment> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Payment> Handle(GetPaymentByRegistrationDetailIdQuery query)
        {
            return _repo.Get(a => a.RegistrationId == query.RegistrationId);
        }
    }
}
