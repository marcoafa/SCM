using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            Waste = new HashSet<Waste>();
        }

        public short ProductId { get; set; }
        public string ProductName { get; set; }

        public ICollection<Waste> Waste { get; set; }
    }
}
