using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Application.Contract.Company
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public int CompanyType { get; set; }
        public string Market { get; set; }

    }
}
