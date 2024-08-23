using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.AbstractDetails
{
    public class AddAbstractCommand : ICommand
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
        public DateTime CreatedOn { get; set; }
        public DateTime UpDatedOn { get; set; }
    }

    public class AddAbstractCommandHandler : ICommandHandler<AddAbstractCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Abstract> _repo;

        public AddAbstractCommandHandler(IUnitOfWork uow, IRepository<Abstract> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddAbstractCommand command)
        {
            var Init = new Abstract
            {
                AbstractId = Guid.NewGuid(),
                Prefix = command.Prefix,
                FirstName = command.FirstName,
                Lastname = command.Lastname,
                Phone = command.Phone,
                Comments = command.Comments,
                ConferenceName = command.ConferenceName,
                Designation = command.Designation,
                Email = command.Email,
                Institution = command.Institution,
                AbstractName = command.AbstractName,
                AbstractTitle = command.AbstractTitle,
                JournalPublication = command.JournalPublication,
                Register = command.Register,
                CreatedOn = DateTime.Now,
                UpDatedOn = DateTime.Now
            };
            _repo.Insert(Init);
            _uow.Save();
        }
    }
}
