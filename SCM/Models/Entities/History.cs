using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public short? CustomerId { get; set; }
        public int? DocumentId { get; set; }
        public string ProductName { get; set; }
        public short? Quantity { get; set; }
        public string ManagementName { get; set; }
        public string ContainerName { get; set; }
        public string Unit { get; set; }
        public DateTime? CreationDate { get; set; }
        public string UserName { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public string LicensePlate { get; set; }

        public Customer Customer { get; set; }
    }
}
