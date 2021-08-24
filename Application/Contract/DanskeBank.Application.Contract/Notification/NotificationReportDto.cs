using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Application.Contract.Notification
{
    public class NotificationReportDto
    {
        public Guid CompanyId { get; set; }
        public List<string> Notifications { get; set; }
    }
}
