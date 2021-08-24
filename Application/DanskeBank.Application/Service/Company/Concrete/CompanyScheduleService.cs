using DanskeBank.Application.BusinessHelper;
using DanskeBank.Application.Contract.Company;
using DanskeBank.Application.Contract.Core;
using DanskeBank.Application.Core.Concrete;
using DanskeBank.Application.Service.Company.Abstract;
using DanskeBank.Domain.Company;
using DanskeBank.Domain.Core.Repository;
using DanskeBank.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DanskeBank.Application.Service.Company.Concrete
{
    public class CompanyScheduleService : GenericService<Domain.Company.CompanySchedule, CompanyScheduleDto, int>, ICompanyScheduleService
    {
        public CompanyScheduleService(
            IRepository<Domain.Company.CompanySchedule, int> repository,
            IMap map) : base(repository, map)
        {

        }


        public ValueResult<int> AddCompanySchedule(CompanyScheduleDto companyScheduleDto)
        {
            bool isCampaignContainsDay = IsCampaignContainsDay(companyScheduleDto.CompanyId, companyScheduleDto.Day);
            if (isCampaignContainsDay)
            {
                return new ValueResult<int>()
                {
                    IsSuccess = false,
                    Message = "CampaignAlreadyContainsDay"
                };
            }

            CompanySchedule companySchedule = _map.Map<CompanySchedule>(companyScheduleDto);
            var result = _repository.Add(companySchedule);

            return new ValueResult<int>()
            {
                Value = result
            };
        }

        public BaseResult AddCompanySchedule(CompanyDto company)
        {
            var scheduler = new CompanyScheduleScheduler(company);
            List<CompanyScheduleDto> companyScheduleDtos = scheduler.CreateCompanySchedule();

            if(companyScheduleDtos != null && companyScheduleDtos.Count != 0)
            {
                companyScheduleDtos.ForEach(companyScheduleDto =>
                {
                    CompanySchedule companySchedule = _map.Map<CompanySchedule>(companyScheduleDto);
                    _repository.Add(companySchedule);
                });
            }

            return new BaseResult();
        }

        /// <summary>
        /// Does company has schedule of day
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        private bool IsCampaignContainsDay(Guid companyId, int day)
        {
            IQueryable<CompanySchedule> companySchedules = _repository.Queryable();
            bool isCampaignContainsDay = companySchedules.Any(x => x.CompanyId.Equals(companyId) && x.Day == day);

            return isCampaignContainsDay;
        }

    }
}
