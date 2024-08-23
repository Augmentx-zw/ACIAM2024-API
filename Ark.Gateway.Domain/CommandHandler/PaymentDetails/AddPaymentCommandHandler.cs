using Ark.Gateway.Domain.CommandHandler;
using Ark.Gateway.Domain.Models;
using System;

namespace Ark.Gateway.Domain.CommandHandler.PaymentDetails
{
    public class AddPaymentCommand : ICommand
    {
        public Guid PaymentId { get; set; }
        public Guid Token { get; set; }
        public double Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public string? ReasonForPayment { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? ReturnURL { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
    public class AddPaymentCommandHandler : ICommandHandler<AddPaymentCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Payment> _repo;

        public AddPaymentCommandHandler(IUnitOfWork uow, IRepository<Payment> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddPaymentCommand command)
        {

            Payment InitPayment = new Payment
            {
                PaymentId = command.PaymentId,
                Token = command.Token,
                Amount = command.Amount,
                CurrencyCode = command.CurrencyCode,
                ReasonForPayment = command.ReasonForPayment,
                ReferenceNumber = command.ReferenceNumber,
                PollUrl = $"payments/check-payment?referenceNumber={command.ReferenceNumber}",
                Status = "Initiated",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now

            };
            _repo.Insert(InitPayment);
            _uow.Save();
        }
    }
}
