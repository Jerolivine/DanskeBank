using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Application.Contract.Company
{
    public class CompanyScheduleDto
    {
        public int Id { get; set; }
        public Guid CompanyId { get; set; }

        /// <summary>
        /// The day when schedule will be run 
        /// </summary>
        public int Day { get; set; }
    }
}
