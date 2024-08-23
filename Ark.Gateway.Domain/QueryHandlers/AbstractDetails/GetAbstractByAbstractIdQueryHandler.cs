using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.AbstractDetails
{
    public class GetAbstractByAbstractIdQuery : IQuery<Abstract>
    {
        public Guid AbstractId { get; set; }
    }

    public class GetAbstractByAbstractIdQueryHandler : IQueryHandler<GetAbstractByAbstractIdQuery, Abstract>
    {
        private readonly IRepository<Abstract> _repo;

        public GetAbstractByAbstractIdQueryHandler(IRepository<Abstract> repo)
        {
            _repo = repo;
        }

        public Abstract Handle(GetAbstractByAbstractIdQuery query)
        {
            return _repo.GetByID(query.AbstractId);
        }
    }
}
