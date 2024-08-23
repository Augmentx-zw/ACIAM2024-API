using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.SpeakerDetails
{
    public class GetSpeakersQuery : IQuery<IEnumerable<Speaker>>
    {

    }
    public class GetSpeakersQueryHandler : IQueryHandler<GetSpeakersQuery, IEnumerable<Speaker>>
    {
        private readonly IRepository<Speaker> _repo;
        public GetSpeakersQueryHandler(IRepository<Speaker> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Speaker> Handle(GetSpeakersQuery query)
        {
            return _repo.Get();
        }
    }
}
