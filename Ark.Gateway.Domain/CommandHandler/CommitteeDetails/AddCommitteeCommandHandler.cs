using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.CommitteeDetails
{
    public class AddCommitteeCommand : ICommand
    {
        public Guid CommitteeId { get; set; }
        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public string? Image { get; set; }
        public string? Institution { get; set; }
        public string? Type { get; set; }
        public string? SubType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpDatedOn { get; set; }
    }

    public class AddCommitteeCommandHandler : ICommandHandler<AddCommitteeCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Committee> _repo;

        public AddCommitteeCommandHandler(IUnitOfWork uow, IRepository<Committee> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddCommitteeCommand command)
        {
            var init = new Committee
            {
                CommitteeId = Guid.NewGuid(),
                Prefix = command.Prefix,
                FirstName = command.FirstName,
                Lastname = command.Lastname,
                Image = command.Image,
                Institution = command.Institution,
                Type = command.Type,
                SubType = command.SubType,
                CreatedOn = DateTime.Now,
                UpDatedOn = DateTime.Now
            };
            _repo.Insert(init);
            _uow.Save();
        }
    }
}
