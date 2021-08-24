using DanskeBank.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Domain.Notification
{
    public class Notification : IEntity<int>
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public string SendDate { get; set; }
    }
}
