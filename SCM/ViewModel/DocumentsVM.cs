using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.ViewModel
{
    public class DocumentsVM
    {
        public int DocumentID { get; set; }
        public string Customer { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
