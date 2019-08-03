using SCM.Models.Entities;
using SCM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(RecicladoraContext context) : base(context)
        {

        }

        public Product GetProduct(string Product)
        {
            return _context.Product.Where(x => x.ProductName == Product).FirstOrDefault();
        }

        
    }
}
