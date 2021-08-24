using DanskeBank.Domain.Company;
using DanskeBank.Infrastructure.EntityFramework.Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Infrastructure.EntityFramework.Core.Repository
{
    public class CompanyScheduleRepository : EFCoreGenericRepository<Domain.Company.CompanySchedule, int>, ICompanyScheduleRepository
    {
        public CompanyScheduleRepository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
