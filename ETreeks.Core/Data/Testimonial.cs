using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Testimonial
    {
        public decimal Id { get; set; }
        public string? Testimonialstext { get; set; }
        public string? Testimonialsstatus { get; set; }
        public decimal? GusersId { get; set; }

        public virtual Guser? Gusers { get; set; }
    }
}
