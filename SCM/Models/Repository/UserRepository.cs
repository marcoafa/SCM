using SCM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.Repository
{
    public class UserRepository: Repository<User>
    {
        public UserRepository(RecicladoraContext context) : base(context)
        {

        }

    }
}
