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

        public async Task<int> CreateBookingRequest(Reservation reservation)
        {
            var param = new DynamicParameters();
            param.Add("GUsers_ID", reservation.GusersId, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Course_ID", reservation.CourseId, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Booking_Package.CreateBookingRequest", param, commandType: CommandType.StoredProcedure);

            int courseid = param.Get<int>("C_id");
            return courseid;
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


    }
}
