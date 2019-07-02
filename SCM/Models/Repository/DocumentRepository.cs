using SCM.Models.Entities;
using SCM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.Repository
{
    public class DocumentRepository: Repository<Document>, IDocument
    {
        public DocumentRepository(RecicladoraContext context) : base(context)
        {

        }

    }
}
