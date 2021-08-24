using DanskeBank.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Domain.Company
{
    public class CompanySchedule : IEntity<int>
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }

        /// <summary>
        /// The day when schedule will be run 
        /// </summary>
        public int Day { get; set; }
    }
}
