using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.ViewModel
{
    public class EditDocumentVM
    {

        public DocumentData DocumentD { get; set; }

        public List<DataProductsEdit> Products { get; set; }

        public DataDocumentVM Data { get; set; }

        public EditDocumentVM()
        {
            Products = new List<DataProductsEdit>();
            Data = new DataDocumentVM();
            DocumentD = new DocumentData();
        }
        public class DataProductsEdit
        {
            public string ProductName { get; set; }
            public int ProductID { get; set; }

            public string ContainerName { get; set; }
            public int ContainerID { get; set; }

            public string ManagementName { get; set; }
            public int ManagementID { get; set; }

            public int Quantity { get; set; }
            public string Unit { get; set; }
        }

    }
}
