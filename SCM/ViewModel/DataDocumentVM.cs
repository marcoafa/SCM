using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.ViewModel
{
    public class DataDocumentVM
    {
        public List<CustomerVM> Customers { get; set; }

        public List<ProductsVM> Products { get; set; }

        public List<ContainersVM> Containers { get; set; }

        public List<ManagementsTypesVM> ManagementsTypes { get; set; }

        public List<UsersVM> Users { get; set; }

        public DocumentData DocumentD { get; set; }

        public DataDocumentVM()
        {
            Customers = new List<CustomerVM>();
            Products = new List<ProductsVM>();
            Containers = new List<ContainersVM>();
            ManagementsTypes = new List<ManagementsTypesVM>();
            Users = new List<UsersVM>();
            DocumentD = new DocumentData();
        }
    }
    public class CustomerVM
    {
        public string CustomerName { get; set; }
        public int CustomerID { get; set; }
    }
    public class ProductsVM
    {
        public string ProductName { get; set; }
        public int ProductID { get; set; }
    }
    public class ContainersVM
    {
        public string ContainerName { get; set; }
        public int ContainerID { get; set; }
    }
    public class ManagementsTypesVM
    {
        public string ManagementName { get; set; }
        public int ManagementID { get; set; }
    }
    public class UsersVM
    {
        public string UsersName { get; set; }
        public int UsersID { get; set; }
    }
    public class DocumentData
    {
        public int DocumentID { get; set; }
        public string Username { get; set; }
        public string Customer { get; set; }
        public string LicensePlate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ReceptionDate { get; set; }

        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public string ClientBussines { get; set; }
    }

}
