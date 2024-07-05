using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Paymant
    {
        public decimal Id { get; set; }
        public DateTime? Expirydate { get; set; }
        public decimal? Balance { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public decimal? Cardnumber { get; set; }
        public decimal? Cvv { get; set; }
    }
}
