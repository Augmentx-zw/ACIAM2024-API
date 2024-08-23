using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.SpeakerDetails
{
    public class AddSpeakerCommand : ICommand
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
        public DateTime CreatedOn { get; set; }
        public DateTime UpDatedOn { get; set; }
    }

    public class AddSpeakerCommandHandler : ICommandHandler<AddSpeakerCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Speaker> _repo;

        public AddSpeakerCommandHandler(IUnitOfWork uow, IRepository<Speaker> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddSpeakerCommand command)
        {
            var newSpeaker = new Speaker
            {
                SpeakerId = Guid.NewGuid(),
                Prefix = command.Prefix,
                FirstName = command.FirstName,
                Lastname = command.Lastname,
                Institution = command.Institution,
                Summery = command.Summery,
                Image = command.Image,
                Details = command.Details,
                Type = command.Type,
                CreatedOn = DateTime.Now,
                UpDatedOn = DateTime.Now
            };

            _repo.Insert(newSpeaker);
            _uow.Save();
        }
    }
}
