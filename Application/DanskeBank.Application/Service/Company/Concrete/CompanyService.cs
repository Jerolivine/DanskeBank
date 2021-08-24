using DanskeBank.Application.Contract.Company;
using DanskeBank.Application.Core.Concrete;
using DanskeBank.Application.Service.Company.Abstract;
using DanskeBank.Domain.Core.Repository;
using DanskeBank.Mapper;
using System;

namespace DanskeBank.Application.Service.Company.Concrete
{
    public class CompanyService : GenericService<Domain.Company.Company,CompanyDto,Guid>, ICompanyService
    {
        public CompanyService(
            IRepository<Domain.Company.Company, Guid> repository,
            IMap map) : base(repository,map)
        {

        }
    }
}
