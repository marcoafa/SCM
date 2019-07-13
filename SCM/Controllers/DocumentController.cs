using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SCM.Models.Interfaces;
using SCM.Models.MyClass;

namespace SCM.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
      
        [HttpPost]
        public IActionResult AddDocument(DocumentInfo DocumentI)
        {

            try
            {

                //var sessionU = HttpContext.Session.GetString("UserS");

                if (DocumentI.ListProducts.Count > 0) {
                    //SAVE WITH PRODUCTS
                    _documentRepository.SaveFullDocument(DocumentI,3);
                }
                else
                {
                    //SAVE WITHOUT PRODUCTS
                    _documentRepository.SaveFullDocument(DocumentI, 2);
                }
                

                return Json("false");
            }
            catch (Exception e)
            {
                return Json("false");
            }


        }

        /// <summary>
        /// METHOD TO EDIT THE DOCUMENT THAT THE USER SELECT
        /// </summary>
        /// <param name="DocumentI">CLASS THAT HAVE ALL THE NEW INFORMATION TO EDIT</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditDocumentAction(DocumentInfo DocumentI)
        {
            try
            {

                _documentRepository.EditFullDocument(DocumentI);
              


                return Json("false");
            }
            catch (Exception e)
            {
                return Json("false");
            }


        }
    }
}
