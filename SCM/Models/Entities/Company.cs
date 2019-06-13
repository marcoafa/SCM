using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class Company
    {
        public Company()
        {
            Document = new HashSet<Document>();
        }

        public byte CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContacName { get; set; }

        public ICollection<Document> Document { get; set; }
    }
}
