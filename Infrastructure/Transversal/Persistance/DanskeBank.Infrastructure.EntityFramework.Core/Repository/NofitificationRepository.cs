using DanskeBank.Domain.Notification;
using DanskeBank.Infrastructure.EntityFramework.Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Infrastructure.EntityFramework.Core.Repository
{
    public class NofitificationRepository : EFCoreGenericRepository<Domain.Notification.Notification, int>, INofitificationRepository
    {
        public NofitificationRepository(EFCoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
