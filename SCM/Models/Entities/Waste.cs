using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class Waste
    {
        public Waste()
        {
            Document = new HashSet<Document>();
        }

        public int WasteId { get; set; }
        public short? ContainerId { get; set; }
        public short? ProductId { get; set; }
        public byte? ManagementId { get; set; }
        public short? Quantity { get; set; }
        public string Unit { get; set; }

        public Container Container { get; set; }
        public ManagementProduct Management { get; set; }
        public Product Product { get; set; }
        public ICollection<Document> Document { get; set; }
    }
}
