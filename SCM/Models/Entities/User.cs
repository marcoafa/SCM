using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Document = new HashSet<Document>();
        }

        public short UsersId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public byte? UserTypeId { get; set; }

        public UserType UserType { get; set; }
        public ICollection<Document> Document { get; set; }
    }
}
