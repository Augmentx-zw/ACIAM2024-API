using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.CommitteeDetails
{
    public class GetCommitteeByCommitteeIdQuery : IQuery<Committee>
    {
        public Guid CommitteeId { get; set; }
    }

    public class GetCommitteeByCommitteeIdQueryHandler : IQueryHandler<GetCommitteeByCommitteeIdQuery, Committee>
    {
        private readonly IRepository<Committee> _repo;

        public GetCommitteeByCommitteeIdQueryHandler(IRepository<Committee> repo)
        {
            _repo = repo;
        }

        public Committee Handle(GetCommitteeByCommitteeIdQuery query)
        {
            return _repo.GetByID(query.CommitteeId);
        }
    }
}
