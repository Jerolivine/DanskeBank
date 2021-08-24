using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Application.Contract.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime SendDate { get; set; }
    }
}
