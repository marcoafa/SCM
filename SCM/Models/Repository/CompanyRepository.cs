using SCM.Models.Entities;
using SCM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.Repository
{
    
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(RecicladoraContext context) : base(context)
        {


        }

        public List<Company> GetAllList()
        {
            return _context.Company.ToList();
            
        }
        public List<Company> GetCompany(string Company)
        {
            return _context.Company.Where(x => x.CompanyName == Company).ToList();
        }
    }
}
