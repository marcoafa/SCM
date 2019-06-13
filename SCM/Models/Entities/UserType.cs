using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public byte UserTypeId { get; set; }
        public string UserType1 { get; set; }

        public ICollection<User> User { get; set; }
    }
}
