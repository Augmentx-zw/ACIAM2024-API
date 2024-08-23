using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.RegistrationDetails
{
    public class AddRegistrationCommand : ICommand
    {
        public Guid RegistrationId { get; set; }
        public Guid PaymentId { get; set; }
        public string? Prefix { get; set; }
        public string? Designation { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? StateOrProvince { get; set; }
        public string? ZipOrPostalCode { get; set; }
        public string? Country { get; set; }
        public string? RegistrationStatus { get; set; }

        //Institution
        public string? Institution { get; set; }
        public string? InstitutionAddress { get; set; }
        public string? InstitutionCity { get; set; }
        public string? InstitutionStateOrProvince { get; set; }
        public string? InstitutionZipOrPostalCode { get; set; }
        public string? InstitutionCountry { get; set; }
        public string? InstitutionContactNumber { get; set; }
        public int YearsEmployed { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpDatedOn { get; set; }
    }

    public class AddRegistrationCommandHandler : ICommandHandler<AddRegistrationCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Registration> _repo;

        public AddRegistrationCommandHandler(IUnitOfWork uow, IRepository<Registration> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(AddRegistrationCommand command)
        {
            var init = new Registration
            {
                RegistrationId = Guid.NewGuid(),
                PaymentId = command.PaymentId,
                Prefix = command.Prefix,
                Designation = command.Designation,
                FirstName = command.FirstName,
                LastName = command.LastName,
                EmailAddress = command.EmailAddress,
                PhoneNumber = command.PhoneNumber,
                StreetAddress = command.StreetAddress,
                City = command.City,
                StateOrProvince = command.StateOrProvince,
                ZipOrPostalCode = command.ZipOrPostalCode,
                Country = command.Country,
                RegistrationStatus = command.RegistrationStatus,

                // Institution
                Institution = command.Institution,
                InstitutionAddress = command.InstitutionAddress,
                InstitutionCity = command.InstitutionCity,
                InstitutionStateOrProvince = command.InstitutionStateOrProvince,
                InstitutionZipOrPostalCode = command.InstitutionZipOrPostalCode,
                InstitutionCountry = command.InstitutionCountry,
                InstitutionContactNumber = command.InstitutionContactNumber,
                YearsEmployed = command.YearsEmployed,

                CreatedOn = DateTime.Now,
                UpDatedOn = DateTime.Now
            };

            _repo.Insert(init);
            _uow.Save();
        }
    }
}
