using Ark.Gateway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ark.Gateway.Domain.QueryHandlers.RegistrationDetails
{
    public class GetRegistrationsQuery: IQuery<IEnumerable<Registration>>
    {

    }
    public class GetRegistrationsQueryHandler : IQueryHandler<GetRegistrationsQuery, IEnumerable<Registration>>
    {
        private readonly IRepository<Registration> _repo;
        public GetRegistrationsQueryHandler(IRepository<Registration> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Registration> Handle(GetRegistrationsQuery query)
        {
            return _repo.Get();
        }
    }
}
