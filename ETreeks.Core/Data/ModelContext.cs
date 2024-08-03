using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ETreeks.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<Contactu> Contactus { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseSession> CourseSessions { get; set; } = null!;
        public virtual DbSet<Guser> Gusers { get; set; } = null!;
        public virtual DbSet<Home> Homes { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Paymant> Paymants { get; set; } = null!;
        public virtual DbSet<Receiver> Receivers { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sender> Senders { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=C##TestTest;PASSWORD=Test321;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##TESTTEST")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("ABOUT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Imagename1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME1");

                entity.Property(e => e.Imagename2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME2");

                entity.Property(e => e.Imagename3)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME3");

                entity.Property(e => e.Imagename4)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME4");

                entity.Property(e => e.Title1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE1");

                entity.Property(e => e.Title2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE2");

                entity.Property(e => e.Title3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE3");

                entity.Property(e => e.Title4)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE4");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(9,6)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(9,6)")
                    .HasColumnName("LONGITUDE");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("CHAT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Chatdate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHATDATE")
                    .HasDefaultValueSql("SYSDATE ");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Message)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.ReceiverId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECEIVER_ID");

                entity.Property(e => e.SenderId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SENDER_ID");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.ChatReceivers)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_RECEIVER_ID");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.ChatSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_SENDER_ID");
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.ToTable("CONTACTUS");

                entity.HasIndex(e => e.Email1, "SYS_C009019")
                    .IsUnique();

                entity.HasIndex(e => e.Email2, "SYS_C009020")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL1");

                entity.Property(e => e.Email2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL2");

                entity.Property(e => e.Message)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Subject)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Accepted_Status)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ACCEPTED_STATUS")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.Category_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Createddate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEDDATE")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Passmark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSMARK");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Trainer_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRAINER_ID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Category_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CAT");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Trainer_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRAINER_IDR");
            });

            modelBuilder.Entity<CourseSession>(entity =>
            {
                entity.ToTable("COURSE_SESSION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AvailableStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AVAILABLE_STATUS");

                entity.Property(e => e.CourseId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.Createddate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEDDATE")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseSessions)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_COURSE");
            });

            modelBuilder.Entity<Guser>(entity =>
            {
                entity.ToTable("GUSERS");

                entity.HasIndex(e => e.Username, "SYS_C009028")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "SYS_C009029")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.AddressId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ADDRESS_ID");

                entity.Property(e => e.BioTrainer)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("BIO_TRAINER");

                entity.Property(e => e.Certificate)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CERTIFICATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE");

                entity.Property(e => e.Registration_Status_Trainer)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRATION_STATUS_TRAINER")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.Role_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SPECIALIZATION");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Gusers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ADDRESSID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Gusers)
                    .HasForeignKey(d => d.Role_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ROLE");
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.ToTable("HOME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Title1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE1");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("NOTIFICATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Message)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Notificationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("NOTIFICATIONDATE");

                entity.Property(e => e.Notificationstatus)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("NOTIFICATIONSTATUS")
                    .HasDefaultValueSql("'unread'");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USERN");
            });

            modelBuilder.Entity<Paymant>(entity =>
            {
                entity.ToTable("PAYMANT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Cardnumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cvv)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CVV");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRYDATE");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");
            });

            modelBuilder.Entity<Receiver>(entity =>
            {
                entity.ToTable("RECEIVER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ChatId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHAT_ID");

                entity.Property(e => e.GuserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GUSER_ID");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Receivers)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_RCHAT_ID");

                entity.HasOne(d => d.Guser)
                    .WithMany(p => p.Receivers)
                    .HasForeignKey(d => d.GuserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_GUSERID2");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("RESERVATION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Completed)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COMPLETED")
                    .HasDefaultValueSql("'No'");

                entity.Property(e => e.Course_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.Finalmark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("FINALMARK");

                entity.Property(e => e.Gusers_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GUSERS_ID");

                entity.Property(e => e.Reservationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("RESERVATIONDATE")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Reservationstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RESERVATIONSTATUS")
                    .HasDefaultValueSql("'Pending'");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Course_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_COURSE2");

                entity.HasOne(d => d.Gusers)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Gusers_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_GUSERSCR");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("REVIEWS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Course_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.Guser_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GUSER_ID");

                entity.Property(e => e.Message)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Reviewdate)
                    .HasColumnType("DATE")
                    .HasColumnName("REVIEWDATE")
                    .HasDefaultValueSql("SYSDATE ");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Course_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_COURSE_ID");

                entity.HasOne(d => d.Guser)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Guser_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_GUSER_ID");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Sender>(entity =>
            {
                entity.ToTable("SENDER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ChatId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHAT_ID");

                entity.Property(e => e.GuserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GUSER_ID");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Senders)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_SCHAT_ID");

                entity.HasOne(d => d.Guser)
                    .WithMany(p => p.Senders)
                    .HasForeignKey(d => d.GuserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_GUSERID1");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Gusers_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GUSERS_ID");

                entity.Property(e => e.Testimonialsstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIALSSTATUS")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.Testimonialstext)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIALSTEXT");

                entity.HasOne(d => d.Gusers)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Gusers_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_GUSERST");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
