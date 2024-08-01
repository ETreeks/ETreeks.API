using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Review
    {
        public decimal Id { get; set; }
        public string? Message { get; set; }
        public DateTime? Reviewdate { get; set; }
        public decimal? Guser_Id { get; set; }
        public decimal? Course_Id { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Guser? Guser { get; set; }
    }
}
