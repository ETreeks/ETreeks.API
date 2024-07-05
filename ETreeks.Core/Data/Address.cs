using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Address
    {
        public Address()
        {
            Gusers = new HashSet<Guser>();
        }

        public decimal Id { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Guser> Gusers { get; set; }
    }
}
