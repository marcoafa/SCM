using SCM.Models.Entities;
using SCM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.Repository
{
    public class ContainerRepository : Repository<Container>, IContainerRepository
    {
        public ContainerRepository(RecicladoraContext context) : base(context)
        {
            

        }

        public Container GetContainer(string Container)
        {
            return _context.Container.Where(x => x.ContainerDescription == Container).FirstOrDefault();
        }
    }
}
