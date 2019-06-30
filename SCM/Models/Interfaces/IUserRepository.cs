using SCM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Models.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {

        string GetUserType(string Username);
    }
}
