using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Sender
    {
        public decimal Id { get; set; }
        public decimal? ChatId { get; set; }
        public decimal? GuserId { get; set; }

        public virtual Chat? Chat { get; set; }
        public virtual Guser? Guser { get; set; }
    }
}
