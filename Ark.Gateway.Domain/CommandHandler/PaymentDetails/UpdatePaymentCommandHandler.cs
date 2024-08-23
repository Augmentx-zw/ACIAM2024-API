using Ark.Gateway.Domain.Models;
using System;

namespace Ark.Gateway.Domain.CommandHandler.PaymentDetails
{
    public class UpDatePaymentCommand : ICommand
    {
        public Guid PaymentId { get; set; }
        public string? Status { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
    public class UpdatePaymentCommandHandler : ICommandHandler<UpDatePaymentCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Payment> _repo;

        public UpdatePaymentCommandHandler(IUnitOfWork uow, IRepository<Payment> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(UpDatePaymentCommand command)
        {
            Payment uPayment = _repo.GetByID(command.PaymentId);
            uPayment.Status = command.Status;
            uPayment.UpdatedOn = DateTime.Now;
            _uow.Save();
        }

    }
}