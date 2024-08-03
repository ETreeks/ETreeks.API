using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Guser
    {
        public Guser()
        {
            ChatReceivers = new HashSet<Chat>();
            ChatSenders = new HashSet<Chat>();
            Courses = new HashSet<Course>();
            Notifications = new HashSet<Notification>();
            Receivers = new HashSet<Receiver>();
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
            Senders = new HashSet<Sender>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? Imagename { get; set; }
        public string? Certificate { get; set; }
        public string? Specialization { get; set; }
        public string? Gender { get; set; }
        public decimal? Phone { get; set; }
        public string? BioTrainer { get; set; }
        public string? Registration_Status_Trainer { get; set; }
        public decimal? Role_Id { get; set; }
        public decimal? AddressId { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Chat> ChatReceivers { get; set; }
        public virtual ICollection<Chat> ChatSenders { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Receiver> Receivers { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Sender> Senders { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
