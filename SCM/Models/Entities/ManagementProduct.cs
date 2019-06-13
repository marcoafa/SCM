using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class ManagementProduct
    {
        public ManagementProduct()
        {
            Waste = new HashSet<Waste>();
        }

        public byte ManagementId { get; set; }
        public string ManagementName { get; set; }

        public ICollection<Waste> Waste { get; set; }
    }
}
