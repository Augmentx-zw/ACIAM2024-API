using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.AbstractDetails
{
    public class DeleteAbstractCommand : ICommand
    {
        public Guid AbstractId { get; set; }
    }
    public class DeleteAbstractCommandHandler : ICommandHandler<DeleteAbstractCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Abstract> _repo;

        public DeleteAbstractCommandHandler(IUnitOfWork uow, IRepository<Abstract> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(DeleteAbstractCommand command)
        {
            var Abstract = _repo.GetByID(command.AbstractId);
            _repo.Delete(Abstract);
            _uow.Save();
        }
    }
}
