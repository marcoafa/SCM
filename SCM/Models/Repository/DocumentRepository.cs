﻿using SCM.Models.Entities;
using SCM.Models.Interfaces;
using SCM.Models.MyClass;
using SCM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}