using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.SpeakerDetails
{
    public class DeleteSpeakerCommand : ICommand
    {
        public Guid SpeakerId { get; set; }
    }
    public class DeleteSpeakerCommandHandler : ICommandHandler<DeleteSpeakerCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Speaker> _repo;

        public DeleteSpeakerCommandHandler(IUnitOfWork uow, IRepository<Speaker> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(DeleteSpeakerCommand command)
        {
            var Speaker = _repo.GetByID(command.SpeakerId);
            _repo.Delete(Speaker);
            _uow.Save();
        }
    }
}
