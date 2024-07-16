using ETreeks.Core.ICommon;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using ETreeks.Infra.Common;
using ETreeks.Infra.Repository;
using ETreeks.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ETreeks.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDbContext, DbContext>();


            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<ILoginService, LoginService>();


            builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
            builder.Services.AddScoped<IRegisterService, RegisterService>();

            builder.Services.AddScoped<IGUsersRepository, GUsersRepository>();
            builder.Services.AddScoped<IGUsersService, GUsersService>();

            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IAdminService, AdminService>();

            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBookingService, BookingService>();

            builder.Services.AddScoped<IHomeRepository, HomeRepository>();
            builder.Services.AddScoped<IHomeService, HomeService>();

            builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
            builder.Services.AddScoped<ITrainerService, TrainerService>();

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();

            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IReviewService, ReviewService>();

            builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            builder.Services.AddScoped<ITestimonialService, TestimonialService>();

            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IReservationService, ReservationService>();

			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();

			builder.Services.AddScoped<IAboutRepository, AboutRepository>();
			builder.Services.AddScoped<IAboutService, AboutService>();

			builder.Services.AddScoped<ICourseSessionRepository, CourseSessionRepository>();
			builder.Services.AddScoped<ICourseSessionService, CourseSessionService>();


            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("policy",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                ("I hate the programming  I hate programming I hate the programming .... " +
                "it work ! ...I love a programming")),
                ClockSkew = TimeSpan.Zero
            }); ;

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("policy");
            app.MapControllers();

            app.Run();
        }
    }
}
