using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.ViewModel
{
    public class HistoryVM
    {
        public List<HistoryDataVM> ListHistory { get; set; }
        public DataDocumentVM Data { get; set; }
        public HistoryVM()
        {
            ListHistory = new List<HistoryDataVM>();
        }
    }
    public class HistoryDataVM
    {
        public int HistoryId { get; set; }
        public int? DocumentId { get; set; }
        public string ProductName { get; set; }
        public short? Quantity { get; set; }
        public string ManagementName { get; set; }
        public string ContainerName { get; set; }
        public string Unit { get; set; }
        public DateTime? CreationDate { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
    }
}
