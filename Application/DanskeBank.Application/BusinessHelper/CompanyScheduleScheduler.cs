using DanskeBank.Application.Contract.Company;
using DanskeBank.Constants.Constants;
using DanskeBank.Constants.Enums;
using System;
using System.Collections.Generic;

namespace DanskeBank.Application.BusinessHelper
{
    public class CompanyScheduleScheduler
    {
        private CompanyDto Company { get; set; }
        public CompanyScheduleScheduler(CompanyDto company)
        {
            Company = company;
        }

        public List<CompanyScheduleDto> CreateCompanySchedule()
        {
            if (Company.Market.Equals(MarketConstants.DENMARK))
            {
                return CreateDenmarkNotificationSchedule();
            }
            else if (Company.Market.Equals(MarketConstants.FINLAND) && IsLargeCompany())
            {
                return CreateFinlandNotificationSchedule();
            }
            else if (Company.Market.Equals(MarketConstants.NORWAY))
            {
                return CreateNorwayNotificationSchedule();
            }
            else if (Company.Market.Equals(MarketConstants.SWEDEN) && (IsSmallCompany() || IsMediumCompany()))
            {
                return CreateSwedenNotificationSchedule();
            }

            return null;
        }

        private bool IsLargeCompany()
        {
            return Company.CompanyType == (int)CompanyType.Large;
        }

        private bool IsSmallCompany()
        {
            return Company.CompanyType == (int)CompanyType.Small;
        }

        private bool IsMediumCompany()
        {
            return Company.CompanyType == (int)CompanyType.Medium;
        }

        private List<CompanyScheduleDto> CreateDenmarkNotificationSchedule()
        {
            return new List<CompanyScheduleDto>()
            {
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 1 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 5 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 10 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 15 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 20 },
            };
        }

        private List<CompanyScheduleDto> CreateFinlandNotificationSchedule()
        {
            return new List<CompanyScheduleDto>()
            {
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 1 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 5 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 10 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 20 },
            };
        }

        private List<CompanyScheduleDto> CreateNorwayNotificationSchedule()
        {
            return new List<CompanyScheduleDto>()
            {
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 1 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 5 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 10 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 20 },
            };
        }

        private List<CompanyScheduleDto> CreateSwedenNotificationSchedule()
        {
            return new List<CompanyScheduleDto>()
            {
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 1 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 7 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 14 },
                new CompanyScheduleDto(){ CompanyId = Company.Id,Day = 28 },
            };
        }
    }
}
