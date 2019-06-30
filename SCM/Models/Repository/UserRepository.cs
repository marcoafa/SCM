using SCM.Models.Entities;
using SCM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(RecicladoraContext context) : base(context)
        {

        }

        public string GetUserType(string Username)
        {
            return _context.User.Where(x => x.UserName == Username).Select(u => u.UserType.UserType1).FirstOrDefault();
        }
    }
}
 