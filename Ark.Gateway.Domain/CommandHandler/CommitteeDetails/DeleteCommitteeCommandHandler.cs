using Ark.Gateway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ark.Gateway.Domain.CommandHandler.CommitteeDetails
{
    public class DeleteCommitteeCommand : ICommand
    {
        public Guid CommitteeId { get; set; }
    }
    public class DeleteCommitteeCommandHandler : ICommandHandler<DeleteCommitteeCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Committee> _repo;

        public DeleteCommitteeCommandHandler(IUnitOfWork uow, IRepository<Committee> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(DeleteCommitteeCommand command)
        {
            var Committee = _repo.GetByID(command.CommitteeId);
            _repo.Delete(Committee);
            _uow.Save();
        }
    }
}
