using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Document = new HashSet<Document>();
            History = new HashSet<History>();
        }

        public short CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAdress { get; set; }
        public string Business { get; set; }
        public string Phone { get; set; }

        public ICollection<Document> Document { get; set; }
        public ICollection<History> History { get; set; }
    }
}
