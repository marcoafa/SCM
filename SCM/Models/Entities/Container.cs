using System;
using System.Collections.Generic;

namespace SCM.Models.Entities
{
    public partial class Container
    {
        public Container()
        {
            Waste = new HashSet<Waste>();
        }

        public short ContainerId { get; set; }
        public string ContainerDescription { get; set; }

        public ICollection<Waste> Waste { get; set; }
    }
}
