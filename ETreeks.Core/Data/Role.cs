using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Role
    {
        public Role()
        {
            Gusers = new HashSet<Guser>();
        }

        public decimal Id { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<Guser> Gusers { get; set; }
    }
}
