using DanskeBank.Application.Contract.Company;
using DanskeBank.Application.Contract.Core;
using DanskeBank.Application.Core.Abstract;
using DanskeBank.Domain.Company;

namespace DanskeBank.Application.Service.Company.Abstract
{
    public interface ICompanyScheduleService : IGenericService<CompanySchedule, CompanyScheduleDto, int>
    {
        ValueResult<int> AddCompanySchedule(CompanyScheduleDto companyScheduleDto);
        BaseResult AddCompanySchedule(CompanyDto company);
    }
}
