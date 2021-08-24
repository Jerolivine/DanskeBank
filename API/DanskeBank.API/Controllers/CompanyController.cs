using DanskeBank.API.Core.Core.Base.Response.Concrete;
using DanskeBank.API.Core.Core.CoreController;
using DanskeBank.Application.Contract.Company;
using DanskeBank.Application.Contract.Core;
using DanskeBank.Application.Service.Company.Abstract;
using DanskeBank.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DanskeBank.API.Controllers
{

    [AllowAnonymous]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;
        private readonly ICompanyScheduleService _companyScheduleService;

        public CompanyController(
            IMap map,
            ICompanyService companyService,
            ICompanyScheduleService companyScheduleService) : base(map)
        {
            _companyService = companyService;
            _companyScheduleService = companyScheduleService;
        }


        [HttpPost("AddCompany")]
        public ValueResponse<Guid> AddCompany([FromBody] CompanyDto request)
        {
            request.Id = Guid.Empty;
            ValueResult<Guid> result = _companyService.Add(request);

            ValueResult<CompanyDto> valueResultCompanyDto = _companyService.Get(result.Value);

            _companyScheduleService.AddCompanySchedule(valueResultCompanyDto.Value);

            ValueResponse<Guid> resposne = _map.Map<ValueResponse<Guid>>(result);
            return resposne;

        }
    }

    
}
