using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain.CommandHandler.RegistrationDetails
{
    public class UpdateRegistrationCommand : ICommand
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
        public DateTime UpDatedOn { get; set; }
    }
    public class UpdateRegistrationCommandHandler : ICommandHandler<UpdateRegistrationCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Registration> _repo;

        public UpdateRegistrationCommandHandler(IUnitOfWork uow, IRepository<Registration> repo)
        {
            _uow = uow;
            _repo = repo;
        }
        public void Handle(UpdateRegistrationCommand command)
        {
            var registration = _repo.GetByID(command.RegistrationId);
            if (registration == null)
            {
                throw new Exception($"Registration with ID {command.RegistrationId} not found.");
            }

            registration.PaymentId = command.PaymentId;
            registration.Prefix = command.Prefix;
            registration.Designation = command.Designation;
            registration.FirstName = command.FirstName;
            registration.LastName = command.LastName;
            registration.EmailAddress = command.EmailAddress;
            registration.PhoneNumber = command.PhoneNumber;
            registration.StreetAddress = command.StreetAddress;
            registration.City = command.City;
            registration.StateOrProvince = command.StateOrProvince;
            registration.ZipOrPostalCode = command.ZipOrPostalCode;
            registration.Country = command.Country;
            registration.RegistrationStatus = command.RegistrationStatus;

            // Update Institution information
            registration.Institution = command.Institution;
            registration.InstitutionAddress = command.InstitutionAddress;
            registration.InstitutionCity = command.InstitutionCity;
            registration.InstitutionStateOrProvince = command.InstitutionStateOrProvince;
            registration.InstitutionZipOrPostalCode = command.InstitutionZipOrPostalCode;
            registration.InstitutionCountry = command.InstitutionCountry;
            registration.InstitutionContactNumber = command.InstitutionContactNumber;
            registration.YearsEmployed = command.YearsEmployed;

            registration.UpDatedOn = DateTime.Now;

            _uow.Save();
        }
    }
}
