using DanskeBank.API.Core.Core.Base.Response.Concrete;
using DanskeBank.API.Core.Core.CoreController;
using DanskeBank.Application.Contract.Company;
using DanskeBank.Application.Contract.Core;
using DanskeBank.Application.Service.Company.Abstract;
using DanskeBank.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DanskeBank.API.Controllers
{

    [AllowAnonymous]
    public class CompanyScheduleController : BaseController
    {
        private readonly ICompanyScheduleService _companyScheduleService;

        public CompanyScheduleController(
            IMap map,
            ICompanyScheduleService companyScheduleService) : base(map)
        {
            _companyScheduleService = companyScheduleService;
        }


        [HttpPost("AddCompanySchedule")]
        public ValueResponse<int> AddCompanySchedule([FromBody] CompanyScheduleDto request)
        {
            ValueResult<int> result = _companyScheduleService.AddCompanySchedule(request);

            ValueResponse<int> resposne = _map.Map<ValueResponse<int>>(result);
            return resposne;

        }
    }
}
