﻿using SCM.Models.Entities;
using SCM.Models.Interfaces;
using SCM.Models.MyClass;
using SCM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SCM.ViewModel.EditDocumentVM;

namespace SCM.Models.Repository
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(RecicladoraContext context) : base(context)
        {

        }
        
        public string SaveFullDocument(DocumentInfo FullDocument, byte DocumentStatus)
        {
            var flag = "true";
            var Document = new Document()
            {
                DocumentId = FullDocument.DocumentID,
                CustomerId = (short)FullDocument.DocumentCustomerID,
                DocumentStatusId = DocumentStatus,
                CompanyId = 1,
                CreationDate = DateTime.Now,
                UserId = (short)FullDocument.DocumentEmployeeID

            };


            try
            {
                _context.Add(Document);
                flag = "DocumentError";
                _context.SaveChanges();



                //METHOD TO SAVE PRODUCTS
                if (DocumentStatus == 3)
                {
                    FullDocument.ListProducts.ForEach(x =>
                    {
                        var Waste = new Waste()
                        {
                            ProductId = (short)x.ProductID,
                            ContainerId = (short)x.ContainerID,
                            ManagementId = (byte)x.ManagementID,
                            Quantity = (short)x.Quantity,
                            Unit = x.Unit,
                            DocumentId = Document.DocumentId


                        };

                        _context.Add(Waste);


                    });
                    flag = "ProductError";
                    _context.SaveChanges();
                }

                flag = "True";
                return flag;
            }
            catch (Exception e)
            {
                return flag;
            }
        }
        public string CompleteFullDocument(DocumentInfo FullDocument)
        {
            var flag = "true";
            var Document = _context.Document
                            .Where(x => x.DocumentId == FullDocument.DocumentID)
                            .FirstOrDefault();




            try
            {
                
                flag = "DocumentError";
                _context.SaveChanges();



             
                FullDocument.ListProducts.ForEach(x =>
                {
                    var Waste = new Waste()
                    {
                        ProductId = (short)x.ProductID,
                        ContainerId = (short)x.ContainerID,
                        ManagementId = (byte)x.ManagementID,
                        Quantity = (short)x.Quantity,
                        Unit = x.Unit,
                        DocumentId = Document.DocumentId


                    };

                    _context.Add(Waste);


                });
                flag = "ProductError";
                _context.SaveChanges();
                

                flag = "True";
                return flag;
            }
            catch (Exception e)
            {
                return flag;
            }
        }
        public string EditFullDocument(DocumentInfo FullDocument)
        {
            var flag = "true";

            var OldDocument =_context.Document
                .Where(x => x.DocumentId == FullDocument.OldDocumentID)
                .FirstOrDefault();
            try
            {
                flag = "errordelete";
                _context.Remove(OldDocument);
                _context.SaveChanges();

                flag = "errorupdate";
                SaveFullDocument(FullDocument,3);

                flag = "True";
                return flag;
            }
            catch (Exception e)
            {
                return flag;
            }
        }
        public List<DocumentsVM> GetFullDocuments() {

            var DocumentsVM = new List<DocumentsVM>();

            DocumentsVM = _context.Document
                .Select(x => new DocumentsVM() {
                    DocumentID = x.DocumentId,
                    Status = x.DocumentStatus.Status,
                    CreationDate = (DateTime)x.CreationDate,
                    Customer = x.Customer.CustomerName,
                    UserName = x.User.UserName
                }).ToList();

            return DocumentsVM;
        }
        public DocumentData GetDataDocumentID(int DocumentID)
        {
            return _context.Document
                .Where(x => x.DocumentId == DocumentID)
                 .Select(x => new DocumentData()
                 {
                     DocumentID = DocumentID,
                     Customer = x.Customer.CustomerName,
                     Username = x.User.UserName
                 }).FirstOrDefault();
        }
            
        public DataDocumentVM GetDatatoFillDocument()
        {
            var DocumentsVM = new DataDocumentVM();

            DocumentsVM.Customers = _context.Customer
                .Select(x => new CustomerVM()
                {
                    CustomerID = x.CustomerId,
                    CustomerName = x.CustomerName
                }).ToList();

            DocumentsVM.Products = _context.Product
                .Select(x => new ProductsVM()
                {
                    ProductID = x.ProductId,
                    ProductName = x.ProductName
                }).ToList();

            DocumentsVM.Containers = _context.Container
                .Select(x => new ContainersVM()
                {
                    ContainerID = x.ContainerId,
                    ContainerName = x.ContainerDescription
                }).ToList();

            DocumentsVM.Users = _context.User
                .Where(y => y.UserTypeId == 3)
                 .Select(x => new UsersVM()
                 {
                     UsersID = x.UsersId,
                     UsersName = x.UserName
                 }).ToList();

            DocumentsVM.ManagementsTypes = _context.ManagementProduct
                .Select(x => new ManagementsTypesVM()
                {
                    ManagementID = x.ManagementId,
                    ManagementName = x.ManagementName
                }).ToList();

            return DocumentsVM;
        }

        public EditDocumentVM GetDataEditDocumentID(int DocumentID)
        {

            var DocumentsVM = new EditDocumentVM();
            DocumentsVM.Data = GetDatatoFillDocument();
            var Documentinfo = _context.Document.Where(x => x.DocumentId == DocumentID).FirstOrDefault();
            DocumentsVM.DocumentD.DocumentID = Documentinfo.DocumentId;
            DocumentsVM.DocumentD.Customer = _context.Customer.Where(u => u.CustomerId == Documentinfo.CustomerId).FirstOrDefault().CustomerName;
            DocumentsVM.DocumentD.Username = _context.User.Where(u => u.UsersId == Documentinfo.UserId).FirstOrDefault().UserName;

            _context.Waste.Where(u => u.DocumentId == Documentinfo.DocumentId).ToList().ForEach(x => {
                var DP = new DataProductsEdit()
                {
                    ProductName = _context.Product.Where(u => u.ProductId == x.ProductId).FirstOrDefault().ProductName,
                   
                    ProductID = x.Product.ProductId,
                    ContainerName = _context.Container.Where(u => u.ContainerId == x.ContainerId).FirstOrDefault().ContainerDescription,
                    ContainerID = x.Container.ContainerId,
                    ManagementName = _context.ManagementProduct.Where(u => u.ManagementId == x.ManagementId).FirstOrDefault().ManagementName,
                   
                    ManagementID = (int)x.ManagementId,
                    Quantity = (int)x.Quantity
                };
                DocumentsVM.Products.Add(DP);
            });
           
            return DocumentsVM;
      
        }
    }
}
