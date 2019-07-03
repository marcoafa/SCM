using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class Document
    {
        public Document()
        {
            Waste = new HashSet<Waste>();
        }

        public int DocumentId { get; set; }
        public short? CustomerId { get; set; }
        public int? WasteId { get; set; }
        public byte? DocumentStatusId { get; set; }
        public short? UserId { get; set; }
        public byte CompanyId { get; set; }
        public DateTime? CreationDate { get; set; }

        public Company Company { get; set; }
        public Customer Customer { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public User User { get; set; }
        public ICollection<Waste> Waste { get; set; }
    }
}
