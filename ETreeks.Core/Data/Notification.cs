using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Notification
    {
        public decimal Id { get; set; }
        public string? Notificationstatus { get; set; }
        public string? Message { get; set; }
        public decimal? UserId { get; set; }
        public DateTime? Notificationdate { get; set; }

        public virtual Guser? User { get; set; }
    }
}
