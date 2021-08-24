using DanskeBank.Domain.Company;
using DanskeBank.Infrastructure.EntityFramework.Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Infrastructure.EntityFramework.Core.Repository
{
    public class CompanyRepository : EFCoreGenericRepository<Domain.Company.Company, Guid>, ICompanyRepository
    {
        public CompanyRepository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
