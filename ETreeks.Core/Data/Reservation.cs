﻿using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Reservation
    {
        public decimal Id { get; set; }
        public string? Reservationstatus { get; set; }
        public DateTime? Reservationdate { get; set; }
        public decimal? GusersId { get; set; }
        public decimal? CourseId { get; set; }
        public decimal? Finalmark { get; set; }
        public string? Completed { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Guser? Gusers { get; set; }
    }
}
