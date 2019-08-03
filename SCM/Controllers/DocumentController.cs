using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SCM.Models.Interfaces;
using SCM.Models.MyClass;
using System.IO;
using OfficeOpenXml;
using SCM.ViewModel;

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
                

                return Json("true");
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
              


                return Json("true");
            }
            catch (Exception e)
            {
                return Json("false");
            }


        }
        [HttpPost]
        public IActionResult ImportDocument()
        {
           var response = _documentRepository.ImportDocuments();
           return Json(response);

        }
        // ESTE METODO ES EL IMPORTANTE SOLO HAS LA CONSULTA y se mete en LIST
        [HttpGet("exportv2")]
        public async Task<IActionResult> ExportV2()
        {
            // query data from database  
            await Task.Yield();
            var ListofHistories = _documentRepository.GetHistoryInformation();
           
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(ListofHistories, true);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Manifiestos-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }

    }
}
