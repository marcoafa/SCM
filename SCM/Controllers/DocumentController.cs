using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SCM.Models.Interfaces;


namespace SCM.Controllers
{
    public class DocumentController : Controller
    {
        [HttpPost]
        public IActionResult AddDocument(DocumentInfo DocumentI)
        {

            try
            {
                //var sessionU = HttpContext.Session.GetString("UserS");
                //var Username = _userRepository.GetAll().ToList().Where(x => x.Name.ToUpper() == sessionU.ToUpper()).FirstOrDefault().Name;
                //var product = _productRepositorycs.GetAll().Where(x => x.Description == NewInventory.ProductDescription).FirstOrDefault();
                //if (product != null)
                //{
                //    var inventory = new WareHouse()
                //    {
                //        CreateDate = DateTime.Now,
                //        UserId = Username,
                //        ProductId = product.ProductId,
                //        Quantity = NewInventory.ProductQuantity,
                //        RealCost = NewInventory.ProductInventoryRealCosts

                //    };

                //    _wareHouseRepository.Create(inventory);
                //    return Json("true");
                //}
                //else
                //{
                //    return Json("NoProduct");
                //}

                return Json("false");
            }
            catch (Exception e)
            {
                return Json("false");
            }


        }
        public class ProductRow
        {
            public int ProductID { get; set; }
            public int ContainerID { get; set; }
            public int ManagementID { get; set; }
            public int Unit { get; set; }
            public int Quantity { get; set; }

        }
        public class DocumentInfo
        {
            public string DocumentID { get; set; }
            public int DocumentCustomerID { get; set; }
            public int DocumentEmployeeID { get; set; }
            public List<ProductRow> ListProducts { get; set; }
            public DocumentInfo()
            {
                ListProducts = new List<ProductRow>();
            }
        }
    }
}
