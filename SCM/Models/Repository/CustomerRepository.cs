using SCM.Models.Entities;
using SCM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.Repository
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(RecicladoraContext context) : base(context)
        {

        }

        public Customer GetCustomer(string Customer)
        {
            return _context.Customer.Where(x => x.CustomerName == Customer).FirstOrDefault();
        }

      

        
    }
  
}
