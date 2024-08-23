using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.AbstractDetails
{
    public class UpdateAbstractCommand : ICommand
    {
        public Guid AbstractId { get; set; }
        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public string? Designation { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Institution { get; set; }
        public string? ConferenceName { get; set; }
        public string? Register { get; set; }
        public string? JournalPublication { get; set; }
        public string? Comments { get; set; }
        public string? AbstractName { get; set; }
        public string? AbstractTitle { get; set; }
        public DateTime UpDatedOn { get; set; }
    }
    public class UpdateAbstractCommandHandler : ICommandHandler<UpdateAbstractCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Abstract> _repo;

        public UpdateAbstractCommandHandler(IUnitOfWork uow, IRepository<Abstract> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(UpdateAbstractCommand command)
        {
            var update = _repo.GetByID(command.AbstractId);
            if (update == null)
            {
                throw new Exception($"Abstract with ID {command.AbstractId} not found.");
            }
            update.Prefix = command.Prefix;
            update.FirstName = command.FirstName;
            update.Lastname = command.Lastname;
            update.Designation = command.Designation;
            update.Email = command.Email;
            update.Phone = command.Phone;
            update.Institution = command.Institution;
            update.ConferenceName = command.ConferenceName;
            update.Register = command.Register;
            update.JournalPublication = command.JournalPublication;
            update.Comments = command.Comments;
            update.AbstractName = command.AbstractName;
            update.AbstractTitle = command.AbstractTitle;
            update.UpDatedOn =DateTime.Now;
            _uow.Save();
        }
    }
}
