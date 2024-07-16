using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Course
    {
        public Course()
        {
            CourseSessions = new HashSet<CourseSession>();
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
        }

        public decimal Id { get; set; }
        public string? Name { get; set; }
        public string? Imagename { get; set; }
        public DateTime? Createddate { get; set; }
        public string? Accepted_Status { get; set; }
        public decimal? Price { get; set; }
        public decimal? Category_Id { get; set; }
        public decimal? Trainer_Id { get; set; }
        public string? Passmark { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Guser? Trainer { get; set; }
        public virtual ICollection<CourseSession> CourseSessions { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
