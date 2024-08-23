using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.SpeakerDetails
{
    public class UpdateSpeakerCommand : ICommand
    {
        public Guid SpeakerId { get; set; }
        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public string? Institution { get; set; }
        public string? Summery { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
        public string? Type { get; set; }
        public DateTime UpDatedOn { get; set; }
    }

    public class UpdateSpeakerCommandHandler : ICommandHandler<UpdateSpeakerCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Speaker> _repo;

        public UpdateSpeakerCommandHandler(IUnitOfWork uow, IRepository<Speaker> repo)
        {
            _uow = uow;
            _repo = repo;
        }

        public void Handle(UpdateSpeakerCommand command)
        {
            var speaker = _repo.GetByID(command.SpeakerId);
            if (speaker == null)
            {
                throw new Exception($"Speaker with ID {command.SpeakerId} not found.");
            }

            speaker.Prefix = command.Prefix;
            speaker.FirstName = command.FirstName;
            speaker.Lastname = command.Lastname;
            speaker.Institution = command.Institution;
            speaker.Summery = command.Summery;
            speaker.Image = command.Image;
            speaker.Details = command.Details;
            speaker.Type = command.Type;
            speaker.UpDatedOn = DateTime.Now;

            _uow.Save();
        }
    }
}
