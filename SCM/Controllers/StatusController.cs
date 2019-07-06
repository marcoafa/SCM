using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCM.Models.Interfaces;
using SCM.Models.MyClass;
using SCM.ViewModel;

namespace SCM.Controllers
{
    public class StatusController : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        public StatusController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public IActionResult CompleteDocument(int DocumentID)
        {
          
            var DataForDocument = _documentRepository.GetDatatoFillDocument();

            DataForDocument.DocumentD = _documentRepository.GetDataDocumentID(DocumentID);
           
            return View(DataForDocument);
        }
        
        [HttpPost]
        public IActionResult AddDocument(DocumentInfo DocumentI)
        {

            try
            {

              
                //SAVE WITH PRODUCTS
                _documentRepository.SaveFullDocument(DocumentI, 3);
               


                return Json("false");
            }
            catch (Exception e)
            {
                return Json("false");
            }


        }
    }
}