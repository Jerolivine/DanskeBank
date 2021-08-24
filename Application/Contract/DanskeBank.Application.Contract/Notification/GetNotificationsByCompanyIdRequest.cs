using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Application.Contract.Notification
{
    public class GetNotificationsByCompanyIdRequest
    {
        public Guid CompanyId { get; set; }
    }
}

