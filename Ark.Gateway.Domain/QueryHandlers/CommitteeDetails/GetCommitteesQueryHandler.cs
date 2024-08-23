using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.CommitteeDetails
{
    public class GetCommitteesQuery : IQuery<IEnumerable<Committee>>
    {

    }
    public class GetCommitteesQueryHandler : IQueryHandler<GetCommitteesQuery, IEnumerable<Committee>>
    {
        private readonly IRepository<Committee> _repo;
        public GetCommitteesQueryHandler(IRepository<Committee> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Committee> Handle(GetCommitteesQuery query)
        {
            return _repo.Get();
        }
    }
}
