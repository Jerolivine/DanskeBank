using DanskeBank.Application.Contract.Core;
using DanskeBank.Application.Contract.Notification;
using DanskeBank.Application.Core.Abstract;
using System;

namespace DanskeBank.Application.Service.Notification.Abstract
{
    public interface INotificationService : IGenericService<DanskeBank.Domain.Notification.Notification, NotificationDto, int>
    {
        ValueResult<NotificationReportDto> GetNotificationsByCompanyId(Guid companyId);
    }
}
