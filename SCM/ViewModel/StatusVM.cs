using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.ViewModel
{
    public class StatusVM
    {
        public List<DocumentsVM> ListDocuments { get; set; }
        public DataDocumentVM Data { get; set; }
        public StatusVM()
        {
            ListDocuments = new List<DocumentsVM>();
        }
    }
}
