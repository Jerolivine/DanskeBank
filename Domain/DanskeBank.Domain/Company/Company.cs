using DanskeBank.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DanskeBank.Domain.Company
{
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }

        [RegularExpression("[0-9]{1,10}", ErrorMessage = "Please enter valid Number")]
        public string CompanyNumber { get; set; }
        public int CompanyType { get; set; }
        public string Market { get; set; }

    }
}
