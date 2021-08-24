using DanskeBank.Application.Contract.Core;
using DanskeBank.Application.Contract.Notification;
using DanskeBank.Application.Core.Concrete;
using DanskeBank.Application.Service.Notification.Abstract;
using DanskeBank.Domain.Core.Repository;
using DanskeBank.Mapper;
using System;
using System.Linq;

namespace DanskeBank.Application.Service.Notification.Concrete
{
    public class NotificationService : GenericService<Domain.Notification.Notification, NotificationDto, int>, INotificationService
    {
        public NotificationService(
            IRepository<Domain.Notification.Notification, int> repository,
            IMap map) : base(repository, map)
        {

        }


        public ValueResult<NotificationReportDto> GetNotificationsByCompanyId(Guid companyId)
        {
            IQueryable<Domain.Notification.Notification> notifications = _repository.Queryable();
            var companyNotifications = notifications.Where(x => x.CompanyId.Equals(companyId)).ToList();

            NotificationReportDto value = new NotificationReportDto()
            {
                CompanyId = companyId
            };

            if (companyNotifications != null || companyNotifications.Count != 0)
            {
                value.Notifications = companyNotifications.Select(x => x.SendDate).ToList();
            }

            return new ValueResult<NotificationReportDto>() { Value = value };

        }

    }
}
