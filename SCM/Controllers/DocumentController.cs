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
using Microsoft.AspNetCore.Hosting;

namespace SCM.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DocumentController(IDocumentRepository documentRepository, IHostingEnvironment hostingEnvironment)
        {
            _documentRepository = documentRepository;
            _hostingEnvironment = hostingEnvironment;
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

       


        //EDIT HISTORY
        [HttpPost]
        public IActionResult EditHistoryAction(DocumentInfo DocumentI)
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

        // Metodo de la magia
        [HttpPost("exportv3")]
        public async Task<IActionResult> ExportV3(int DocumentID)
        {
            // query data from database  
            await Task.Yield();


            // Obtener archivo, crea dentro de wwwroot una carpeta que se llame docs y ahi metes el archivo 
            // yo le puse Layout.xlsx
            var rootDirectory = _hostingEnvironment.WebRootPath;
            var fileName = @"Layout.xlsx";
            var docPath = Path.Combine(rootDirectory, "docs", fileName);


            var stream = new MemoryStream();

            using (var fs = new FileStream(docPath, FileMode.Open, FileAccess.ReadWrite)) // Abres el archivo en un stream
            {
                using (var package = new ExcelPackage(fs))
                {
                    var workSheet = package.Workbook.Worksheets[2]; // Aqui obtienes la hoja
                    // Aqui fumo (-_-) , para llenar hardcodee los valores estan justo donde los pusiste 
                    // asi que ahi tu las llenas con interfaces y tus fumaditas
                    workSheet.Cells["C3"].Value = "                                             PLUMA NACIONAL S.A DE C.V.";
                    workSheet.Cells["C4"].Value = "              AV. DE LOS CABOS 13382 PARQUE INDUSTRIAL PACIFICO  CP. 22646 TIJUANA B.C.";
                    workSheet.Cells["C5"].Value = "                                        FABRICACION DE PLUMAS";
                    workSheet.Cells["F4"].Value = "                                                (664) 211- 6200";
                    workSheet.Cells["C25"].Value = "                                                                                 AN-13-011		";
                    workSheet.Cells["C27"].Value = "                                                                          14-AGOSTO-2019		";
                    workSheet.Cells["C31"].Value = "                                                                                                                  SALES DE PLUMA NACIONAL  TOMAS CAMINO HACIA VIA RAPIDA, TE SALES EN EL PUENTE DE LA BUENA VISTA Y LLEGAS A LA 20 DE NOVIEMBRE.";
                    workSheet.Cells["C32"].Value = "                                                                    MATERIALES ARJAMEX, S.A. DE C.V. 		";
                    workSheet.Cells["C33"].Value = "                                                   CALLE 22 DE NOVIEMBRE 105, COL. 20 DE NOVIEMBRE		";
                    workSheet.Cells["C34"].Value = "                                                                                              PS-TIJ-012/15		";
                    workSheet.Cells["C35"].Value = "                                                                          14-AGOSTO-2019		";
                    workSheet.Cells["F33"].Value = "                                              (664)  622-2290	";

                 

                    var DataForDocument = _documentRepository.GetDataEditDocumentID(DocumentID);

                    
                    
                    // Aqui llene los articulos supongo que eso es (como tengo que fumar pues quien sabe (r.r) )
                   
                    workSheet.Cells["C11"].LoadFromCollection(DataForDocument.Products.Select(x => new { // ni modo a fumar
                        x.ProductName,
                        x.Quantity,
                        x.Unit,
                        x.ContainerName,
                        x.ManagementID
                    }), false);
                    // Fumar como en apriso y las mismas explicaciones por osmosis

                    package.SaveAs(stream); // Aqui haces la copia
                }
            }

            stream.Position = 0;
            string excelName = $"MAnifiesto-{DocumentID}--{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
