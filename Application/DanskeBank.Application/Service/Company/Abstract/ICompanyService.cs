using DanskeBank.Application.Contract.Company;
using DanskeBank.Application.Core.Abstract;
using System;

namespace DanskeBank.Application.Service.Company.Abstract
{
    public interface ICompanyService : IGenericService<DanskeBank.Domain.Company.Company, CompanyDto, Guid>
    {

    }
}
