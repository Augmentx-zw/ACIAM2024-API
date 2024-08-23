using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.AbstractDetails
{
    public class GetAbstractsQuery : IQuery<IEnumerable<Abstract>>
    {

    }
    public class GetAbstractsQueryHandler : IQueryHandler<GetAbstractsQuery, IEnumerable<Abstract>>
    {
        private readonly IRepository<Abstract> _repo;
        public GetAbstractsQueryHandler(IRepository<Abstract> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Abstract> Handle(GetAbstractsQuery query)
        {
            return _repo.Get();
        }
    }
}
