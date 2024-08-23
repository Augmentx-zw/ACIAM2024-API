using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.RegistrationDetails
{
    public class GetRegistrationByRegistrationIdQuery : IQuery<Registration>
    {
        public Guid RegistrationId { get; set; }
    }

    public class GetRegistrationByRegistrationIdQueryHandler : IQueryHandler<GetRegistrationByRegistrationIdQuery, Registration>
    {
        private readonly IRepository<Registration> _repo;

        public GetRegistrationByRegistrationIdQueryHandler(IRepository<Registration> repo)
        {
            _repo = repo;
        }

        public Registration Handle(GetRegistrationByRegistrationIdQuery query)
        {
            return _repo.GetByID(query.RegistrationId);
        }
    }
}
