using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.MyClass
{
    public class ProductRow
    {
        public int ProductID { get; set; }
        public int ContainerID { get; set; }
        public int ManagementID { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
    }
}
