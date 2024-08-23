using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.CommitteeDetails
{
    public class UpdateCommitteeCommand : ICommand
    {
        public Guid CommitteeId { get; set; }
        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public string? Image { get; set; }
        public string? Institution { get; set; }
        public string? Type { get; set; }
        public string? SubType { get; set; }
        public DateTime UpDatedOn { get; set; }
    }
    public class UpdateCommitteeCommandHandler : ICommandHandler<UpdateCommitteeCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Committee> _repo;

        public UpdateCommitteeCommandHandler(IUnitOfWork uow, IRepository<Committee> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(UpdateCommitteeCommand command)
        {
            var update = _repo.GetByID(command.CommitteeId);
            if (update == null)
            {
                throw new Exception($"Committee with ID {command.CommitteeId} not found.");
            }
            update.Prefix = command.Prefix;
            update.FirstName = command.FirstName;
            update.Lastname = command.Lastname;
            update.Image = command.Image;
            update.Institution = command.Institution;
            update.Type = command.Type;
            update.SubType = command.SubType;
            update.UpDatedOn = DateTime.Now;
            _uow.Save();
        }
    }
}
