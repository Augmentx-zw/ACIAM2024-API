using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.PaymentDetails
{
    public class GetPaymentByPaymentIdQuery : IQuery<Payment>
    {
        public Guid PaymentId { get; set; }
    }

    public class GetPaymentByPaymentIdQueryHandler : IQueryHandler<GetPaymentByPaymentIdQuery, Payment>
    {
        private readonly IRepository<Payment> _repo;

        public GetPaymentByPaymentIdQueryHandler(IRepository<Payment> repo)
        {
            _repo = repo;
        }
        public Payment Handle(GetPaymentByPaymentIdQuery query)
        {
            return _repo.GetByID(query.PaymentId);
        }
    }
}
