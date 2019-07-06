using SCM.Models.Entities;
using SCM.Models.MyClass;
using SCM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.Interfaces
{
    public interface IDocumentRepository : IRepository<Document>
    {
        DataDocumentVM GetDatatoFillDocument();
        //DataDocumentVM GetDataForFinishDocument(int DocumentID);

        string SaveFullDocument(DocumentInfo FullDocument, byte DocumentStatus);
        DocumentData GetDataDocumentID(int DocumentID);
        string CompleteFullDocument(DocumentInfo FullDocument);
        List<DocumentsVM> GetFullDocuments();
       

    }
}
