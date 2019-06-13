using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class DocumentStatus
    {
        public DocumentStatus()
        {
            Document = new HashSet<Document>();
        }

        public byte DocumentStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Document> Document { get; set; }
    }
}
