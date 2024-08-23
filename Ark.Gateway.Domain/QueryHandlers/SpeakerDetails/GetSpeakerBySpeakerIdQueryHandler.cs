using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.QueryHandlers.SpeakerDetails
{
    public class GetSpeakerBySpeakerIdQuery : IQuery<Speaker>
    {
        public Guid SpeakerId { get; set; }
    }

    public class GetSpeakerBySpeakerIdQueryHandler : IQueryHandler<GetSpeakerBySpeakerIdQuery, Speaker>
    {
        private readonly IRepository<Speaker> _repo;

        public GetSpeakerBySpeakerIdQueryHandler(IRepository<Speaker> repo)
        {
            _repo = repo;
        }

        public Speaker Handle(GetSpeakerBySpeakerIdQuery query)
        {
            return _repo.GetByID(query.SpeakerId);
        }
    }
}
