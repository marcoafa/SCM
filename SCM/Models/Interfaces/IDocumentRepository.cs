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
        string CompleteFullDocument(DocumentInfo FullDocument);
        string EditFullDocument(DocumentInfo FullDocument);

        DocumentData GetDataDocumentID(int DocumentID);
        List<DocumentsVM> GetFullDocuments();
        EditDocumentVM GetDataEditDocumentID(int DocumentID);
        List<HistoryDataVM> GetHistoryInformation();
        List<HistoryDataVM> GetHistoryInformation(int DocumentID);
        List<HistoryDataVM> GetHistoryInformation(int Customer, int Product);
        List<HistoryDataVM> GetHistoryInformation(DateTime InitialDate, DateTime FinalDate);
        string ImportDocuments();
        void RemoveAll(List<Document> Documents);

    }
}
