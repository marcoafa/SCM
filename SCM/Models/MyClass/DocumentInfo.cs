using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.MyClass
{
    public class DocumentInfo
    {
        public int DocumentID { get; set; }
        public int DocumentCustomerID { get; set; }
        public int DocumentEmployeeID { get; set; }
        public List<ProductRow> ListProducts { get; set; }
        public int OldDocumentID { get; set; }
        public string DocumentPlate { get; set; }
        public DateTime? DocumentDateRe { get; set; }
        public DateTime? DocumentDateRo { get; set; }

       
        

        public DocumentInfo()
        {
            ListProducts = new List<ProductRow>();
        }
    }
}
