using Dapper;
using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.ICommon;
using ETreeks.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContext _dbContext;

        public StudentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateBookingRequest(Reservation reservation)
        {
            var param = new DynamicParameters();
            param.Add("GUsers_ID", reservation.Gusers_Id, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Course_ID", reservation.Course_Id, dbType: DbType.String, direction: ParameterDirection.Input);
            //param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
			//:)
            //var result = 
				await _dbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.CreateBookingRequest", param, commandType: CommandType.StoredProcedure);

            //int courseid = param.Get<int>("C_id");
            //return courseid;
        }
        public async Task<List<Notification>> GetNotificationsForUser(int userId)
        {
            var p = new DynamicParameters();
            p.Add("p_user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Notification>("STUDENT_PACKAGE.GET_NOTIFICATIONS_FOR_USER", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task DeleteNotification(int id)
        {
            var param = new DynamicParameters();
            param.Add("Nid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.DeleteNotification", param, commandType: CommandType.StoredProcedure);

        }
        public List<SessionDTO> GetTrainerSessionsByID(int trainerId)
        {
            var p = new DynamicParameters();
            p.Add("trainer_id", trainerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<SessionDTO>("STUDENT_PACKAGE.GetTrainerSessionsByID", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<SessionDTO> GetTrainerSessionsByUsername(string username)
        {
            var p = new DynamicParameters();
            p.Add("trainer_username", username, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<SessionDTO>("STUDENT_PACKAGE.GetTrainerSessionsByUsername", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

		public async Task<ProfileStudentDTO> Viewprofile(int id)
		{
			var param = new DynamicParameters();
			param.Add("User_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			using (var connection = _dbContext.Connection)
			{
				var result = await connection.QueryAsync<ProfileStudentDTO, AddressDto, ProfileStudentDTO>(
					"STUDENT_PACKAGE.VIEW_PROFILESTUDENT",
					(profile, address) =>
					{
						profile.Address = address;
						return profile;
					},
					param,
					commandType: CommandType.StoredProcedure,
					splitOn: "LONGITUDE");

				return result.FirstOrDefault();
			}
		}

		public async Task<bool> UpdateProfile(ProfileStudentDTO profileStudentDto)
		{
			var param = new DynamicParameters();
			param.Add("User_ID", profileStudentDto.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			param.Add("new_Password", profileStudentDto.Password, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Fname", profileStudentDto.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Lname", profileStudentDto.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Email", profileStudentDto.Email, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_ImageName", profileStudentDto.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Phone", profileStudentDto.Phone, dbType: DbType.Int64, direction: ParameterDirection.Input);
			param.Add("new_Longitude", profileStudentDto.Address.Longitude, dbType: DbType.Double, direction: ParameterDirection.Input);
			param.Add("new_Latitude", profileStudentDto.Address.Latitude, dbType: DbType.Double, direction: ParameterDirection.Input);
			param.Add("new_City", profileStudentDto.Address.City, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Country", profileStudentDto.Address.Country, dbType: DbType.String, direction: ParameterDirection.Input);

			using (var connection = _dbContext.Connection)
			{
				await connection.ExecuteAsync("STUDENT_PACKAGE.UPDATE_PROFILESTUDENT", param, commandType: CommandType.StoredProcedure);
				return true;
			}
		}
	}
}
