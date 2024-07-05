using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Chat
    {
        public Chat()
        {
            Receivers = new HashSet<Receiver>();
            Senders = new HashSet<Sender>();
        }

        public decimal Id { get; set; }
        public string? Message { get; set; }
        public DateTime? Chatdate { get; set; }
        public decimal? SenderId { get; set; }
        public decimal? ReceiverId { get; set; }
        public string? Imagename { get; set; }

        public virtual Guser? Receiver { get; set; }
        public virtual Guser? Sender { get; set; }
        public virtual ICollection<Receiver> Receivers { get; set; }
        public virtual ICollection<Sender> Senders { get; set; }
    }
}
