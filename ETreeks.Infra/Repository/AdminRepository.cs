﻿using Dapper;
using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.ICommon;
using ETreeks.Core.IRepository;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IDbContext _dbContext;

        public AdminRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ReservationDate>> GetAllReservation()
        {
            var result = await _dbContext.Connection.QueryAsync<ReservationDate>("Admin_Package.GetAllReservation", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task<int> DeleteUser(int id)
        {
            var param = new DynamicParameters();
            param.Add("User_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var result = await _dbContext.Connection.ExecuteAsync("Admin_Package.DeleteUser", param, commandType: CommandType.StoredProcedure);
            int courseid = param.Get<int>("C_id");
            return courseid;
        }

        public async Task<List<StudentInfo>> DisplayAllStudents()
        {
            //var result = await _dbContext.Connection.QueryAsync<Guser>("Admin_Package.DisplayAllStudents", commandType: CommandType.StoredProcedure);
            //return result.ToList();
            var result = await _dbContext.Connection.QueryAsync<AddressDto, StudentInfo, StudentInfo>("Admin_Package.DisplayAllStudents",
             (address, guser) =>
              {
                  guser.Address = address;
                  return guser;
              },

             splitOn: "id",
             commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<Guser>> DisplayAllTrainers()
        {
            var result = await _dbContext.Connection.QueryAsync<Address, Guser, Guser>("Admin_Package.DisplayAllTrainers",
           (address, guser) =>
           {
               guser.Address = address;
               return guser;
           },

           splitOn: "id",
           commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public async Task<List<Guser>> DisplayAllUsers()
        {
            //var result = await _dbContext.Connection.QueryAsync<Guser>("Admin_Package.DisplayAllUsers", commandType: CommandType.StoredProcedure);
            //return result.ToList();

            var result = await _dbContext.Connection.QueryAsync<Address, Guser, Guser>("Admin_Package.DisplayAllUsers",
         (address, guser) =>
         {
             guser.Address = address;
             return guser;
         },

         splitOn: "id",
         commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public async Task<List<PendingTrainerDTO>> GetAllPendingTrainer()
        {
            var result = await _dbContext.Connection.QueryAsync<PendingTrainerDTO>("Admin_Package.GetAllPendingTrainer", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public async Task<int> GetCountAcceptedTrainers()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
            "Admin_Package.GetCountAcceptedTrainers",
             commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> GetCountAdmin()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
            "Admin_Package.GetCountAdmin",
            commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> GetCountCategories()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
            "Admin_Package.GetCountCategories",
            commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> GetCountCourses()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
            "Admin_Package.GetCountCourses",
            commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> GetCountPendingTrainers()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
           "Admin_Package.GetCountPendingTrainers",
           commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> GetCountStudents()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
            "Admin_Package.GetCountStudents",
             commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> GetCountTrainers()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
           "Admin_Package.GetCountTrainers",
            commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<int> GetCountUsers()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
          "Admin_Package.GetCountUsers",
           commandType: CommandType.StoredProcedure);

            return result;
        }



        public async Task<List<TotalCourses>> TotalCoursesInEachCategory()
        {
            var result = _dbContext.Connection.Query<TotalCourses>("Admin_Package.TotalCoursesInEachCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<TotalStudents>> TotalStudentInEachCourse()
        {
            var result = _dbContext.Connection.Query<TotalStudents>("Admin_Package.TotalStudentInEachCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<TotalStdPerTrainer>> TotalStudentsPerTrainer()
        {
            var result = _dbContext.Connection.Query<TotalStdPerTrainer>("Admin_Package.TotalStudentsPerTrainer", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<TrainerWithStudents>> GetStudentsPerTrainer()
        {
            //var result = await _dbContext.Connection.QueryAsync<GetStdPerTrainer>("Admin_Package.GetStudentsPerTrainer", commandType: CommandType.StoredProcedure);
            //return result.ToList();

            var result = await _dbContext.Connection.QueryAsync<TrainerWithStudents, StudentDetail, TrainerWithStudents>
           ("Admin_Package.GetStudentsPerTrainer",
           (trainer, student) =>
           {
               trainer.Students = trainer.Students ?? new List<StudentDetail>();
               trainer.Students.Add(student);
               return trainer;
           },
           splitOn: "StudentUsername",
           commandType: CommandType.StoredProcedure);


            return result.ToList();
        }

        public async Task<int> GetCountPendingReservation()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
            "Admin_Package.GetCountPendingReservation",
             commandType: CommandType.StoredProcedure);

            return result;
        }


        public async Task AcceptProfileAdmin(int userId, string newRegistrationStatus)
        {
            var parameters = new DynamicParameters();
            parameters.Add("User_ID", userId, DbType.Int32);
            parameters.Add("new_Registration_Status", newRegistrationStatus, DbType.String);

            await _dbContext.Connection.ExecuteAsync("ADMIN_PACKAGE.ACCEPT_PROFILEADMIN", parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<Guser> GetProfileAdmin(int userId)
        {
            var param = new DynamicParameters();
            param.Add("User_ID", userId, DbType.Int32, ParameterDirection.Input);

            using (var result = await _dbContext.Connection.QueryMultipleAsync("ADMIN_PACKAGE.GET_PROFILEADMIN", param, commandType: CommandType.StoredProcedure))
            {
                var user = await result.ReadFirstOrDefaultAsync<Guser>();
                return user;
            }
        }

        public async Task UpdateProfileAdmin(UpdateProfileAdminDto updateProfileAdminDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("User_ID", updateProfileAdminDto.UserId, DbType.Int32);
            parameters.Add("new_Username", updateProfileAdminDto.NewUsername, DbType.String);
            parameters.Add("new_Password", updateProfileAdminDto.NewPassword, DbType.String);
            parameters.Add("new_Fname", updateProfileAdminDto.NewFname, DbType.String);
            parameters.Add("new_Lname", updateProfileAdminDto.NewLname, DbType.String);
            parameters.Add("new_Email", updateProfileAdminDto.NewEmail, DbType.String);
            parameters.Add("new_ImageName", updateProfileAdminDto.NewImageName, DbType.String);
            parameters.Add("new_Gender", updateProfileAdminDto.NewGender, DbType.String);
            parameters.Add("new_Phone", updateProfileAdminDto.NewPhone, DbType.Decimal);

            await _dbContext.Connection.ExecuteAsync("ADMIN_PACKAGE.UPDATE_PROFILEADMIN", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> GetCountAcceptedReservation()
        {
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<int>(
             "Admin_Package.GetCountAcceptedReservation",
              commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task AccepttesTimonial(int id)
        {
            var param = new DynamicParameters();
            param.Add("testimonial_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Admin_Package.AcceptTestimonial", param, commandType: CommandType.StoredProcedure);

        }

        public async Task AccepttesCourse(int id)
        {
            var param = new DynamicParameters();
            param.Add("course_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Admin_Package.AcceptCourse", param, commandType: CommandType.StoredProcedure);
        }


		public List<Guser> SearchTrainerByName(string trainerName)
		{
			string query = "ADMIN_PACKAGE.SEARCHFORTRAINERNAME";

			var parameters = new DynamicParameters();
			parameters.Add("Trainer_Name", trainerName, DbType.String, ParameterDirection.Input);

			using (var multi = _dbContext.Connection.QueryMultiple(query, parameters, commandType: CommandType.StoredProcedure))
			{
				return multi.Read<Guser>().ToList();
			}
		}
		//public async Task<int> ApproveTrainer(int trainerId)
		//{
		//	var param = new DynamicParameters();
		//	param.Add("Trainer_ID", trainerId, DbType.Int32, ParameterDirection.Input);
		//	return await _dbContext.Connection.ExecuteAsync("Admin_Package.ApproveTrainer", param, commandType: CommandType.StoredProcedure);
		//}

		public async Task<int> RemoveTrainer(int trainerId)
        {
            var param = new DynamicParameters();
            param.Add("Trainer_ID", trainerId, DbType.Int32, ParameterDirection.Input);
            return await _dbContext.Connection.ExecuteAsync("Admin_Package.RemoveTrainer", param, commandType: CommandType.StoredProcedure);
        }


		public async Task<int> ApproveTrainer(int trainerId)
		{
			var param = new DynamicParameters();
			param.Add("Trainer_ID", trainerId, DbType.Int32, ParameterDirection.Input);

			// Log parameters and the procedure name
			Console.WriteLine($"Calling procedure with Trainer_ID: {trainerId}");

			int result = await _dbContext.Connection.ExecuteAsync("Admin_Package.ApproveTrainer", param, commandType: CommandType.StoredProcedure);

			// Log the result of the procedure call
			Console.WriteLine($"Procedure result: {result}");

			return result;
		}

		//public async Task<string> GetTrainerEmail(int trainerId)
		//      {
		//          var sql = "Admin_Package.GetTrainerEmail";

		//          using (var multi = await _dbContext.Connection.QueryMultipleAsync(
		//              sql,
		//              new { trainer_id = trainerId },
		//              commandType: CommandType.StoredProcedure))
		//          {
		//              var email = await multi.ReadFirstOrDefaultAsync<string>();
		//              return email;
		//          }
		//      }
		public async Task<string> GetTrainerEmail(int trainerId)
		{
			var sql = "Admin_Package.GetTrainerEmail";

			var email = await _dbContext.Connection.QuerySingleOrDefaultAsync<string>(
				sql,
				new { Trainer_ID = trainerId },
				commandType: CommandType.StoredProcedure
			);

			return email;
		}



	}
}
