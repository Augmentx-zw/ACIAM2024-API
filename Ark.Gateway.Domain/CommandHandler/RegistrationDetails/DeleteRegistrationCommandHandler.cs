using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.RegistrationDetails
{
    public class DeleteRegistrationCommand : ICommand
    {
        public Guid RegistrationId { get; set; }
    }
    public class DeleteRegistrationCommandHandler : ICommandHandler<DeleteRegistrationCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Registration> _repo;

        public DeleteRegistrationCommandHandler(IUnitOfWork uow, IRepository<Registration> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(DeleteRegistrationCommand command)
        {
            var Registration = _repo.GetByID(command.RegistrationId);
            _repo.Delete(Registration);
            _uow.Save();
        }
    }
}
