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
    public class TrainerRepository : ITrainerRepository
    {
        private readonly IDbContext _dbContext;

        public TrainerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //public List<TrainerSearch> Search(DateTime startDate, DateTime endDate)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("DateFrom", startDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        //    p.Add("DateTo", endDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        //    var result = _dbContext.Connection.Query<TrainerSearch>("Trainer_Package.GetReservationsInfoByInterval", p, commandType: CommandType.StoredProcedure);
        //    return result.ToList();
        //}
        public List<TrainerSearch> Search(DateTime startDate, DateTime endDate, int trainerId)
        {
            var p = new DynamicParameters();
            p.Add("DateFrom", startDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DateTo", endDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("TrainerId", trainerId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<TrainerSearch>("Trainer_Package.GetInfoByInterval", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task<List<ReservationDate>> GetAllReservationT(int id)
        {
            var param = new DynamicParameters();
            param.Add("TrainerId", id, DbType.Int32, ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<ReservationDate>("Trainer_Package.GetAllReservationT", param, commandType: CommandType.StoredProcedure);
            //var result = await _dbContext.Connection.QueryAsync<ReservationDate>("TRAINER_PACKAGE.GetAllReservationT", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            var param = new DynamicParameters();
            param.Add("Reservation_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Reservation>("Reservation_Pkg.GET_RESERVATION_BY_ID", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task AcceptReservationAsync(int reservationId)
        {
            var param = new DynamicParameters();
            param.Add("reservation_id", reservationId, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Trainer_Package.AcceptReservation", param, commandType: CommandType.StoredProcedure);
            // :)
        }


        public async Task RejectReservationAsync(int reservationId)
        {
            var param = new DynamicParameters();
            param.Add("reservation_id", reservationId, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Trainer_Package.RejectReservation", param, commandType: CommandType.StoredProcedure);
            // :)
        }

        public async Task<List<Reservation>> GetAllPendingReservation()
        {
            var result = await _dbContext.Connection.QueryAsync<Reservation>("Trainer_Package.GetAllPendingReservation", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        //public async Task<ProfileTrainerDTO> ViewProfile(int id)
        //{
        //	var param = new DynamicParameters();
        //	param.Add("User_ID", id, DbType.Int32, ParameterDirection.Input);

        //	using (var connection = _dbContext.Connection)
        //	{
        //		var result = await connection.QueryAsync<ProfileTrainerDTO, AddressDto, ProfileTrainerDTO>(
        //			"TRAINER_PACKAGE.VIEW_PROFILETRAINER",
        //			(profile, address) =>
        //			{
        //				profile.Address = address;
        //				return profile;
        //			},
        //			param,
        //			commandType: CommandType.StoredProcedure,
        //			splitOn: "LONGITUDE");

        //		return result.FirstOrDefault();
        //	}
        //}

        //public async Task<bool> UpdateProfile(ProfileTrainerDTO profileTrainerDto)
        //{
        //	var param = new DynamicParameters();
        //	param.Add("User_ID", profileTrainerDto.Id, DbType.Int32, ParameterDirection.Input);
        //	param.Add("new_Username", profileTrainerDto.Username, DbType.String, ParameterDirection.Input);
        //	param.Add("new_Password", profileTrainerDto.Password, DbType.String, ParameterDirection.Input);
        //	param.Add("new_Fname", profileTrainerDto.Fname, DbType.String, ParameterDirection.Input);
        //	param.Add("new_Lname", profileTrainerDto.Lname, DbType.String, ParameterDirection.Input);
        //	param.Add("new_Email", profileTrainerDto.Email, DbType.String, ParameterDirection.Input);
        //	param.Add("new_ImageName", profileTrainerDto.Imagename, DbType.String, ParameterDirection.Input);
        //	param.Add("new_Specialization", profileTrainerDto.Specialization, DbType.String, ParameterDirection.Input);
        //	param.Add("new_Gender", profileTrainerDto.Gender, DbType.String, ParameterDirection.Input);
        //	param.Add("new_Phone", profileTrainerDto.Phone, DbType.Int64, ParameterDirection.Input);
        //	param.Add("new_Bio_Trainer", profileTrainerDto.Bio_Trainer, DbType.String, ParameterDirection.Input);
        //	param.Add("new_Longitude", profileTrainerDto.Address.Longitude, DbType.Double, ParameterDirection.Input);
        //	param.Add("new_Latitude", profileTrainerDto.Address.Latitude, DbType.Double, ParameterDirection.Input);
        //	param.Add("new_City", profileTrainerDto.Address.City, DbType.String, ParameterDirection.Input);
        //	param.Add("new_Country", profileTrainerDto.Address.Country, DbType.String, ParameterDirection.Input);

        //	using (var connection = _dbContext.Connection)
        //	{
        //		await connection.ExecuteAsync("TRAINER_PACKAGE.UPDATE_PROFILETRAINER", param, commandType: CommandType.StoredProcedure);
        //		return true;
        //	}
        //}

        public async Task<ProfileTrainerDTO> ViewProfile(int id)
        {
            var param = new DynamicParameters();
            param.Add("User_ID", id, DbType.Int32, ParameterDirection.Input);

            var sql = @"SELECT 
                g.ID,
                g.Username, 
                g.Password, 
                g.Fname, 
                g.Lname, 
                g.Email, 
                g.ImageName, 
                g.Certificate, 
                g.Specialization, 
                g.Gender, 
                g.Phone,
                g.Bio_Trainer,
                a.ID AS AddressId,
                a.LONGITUDE, 
                a.LATITUDE, 
                a.CITY, 
                a.COUNTRY
            FROM GUsers g
            LEFT JOIN ADDRESS a ON g.ADDRESS_ID = a.ID
            WHERE g.ID = :User_ID AND g.Role_ID = 2";

            using (var connection = _dbContext.Connection)
            {
                var result = await connection.QueryAsync<ProfileTrainerDTO, AddressDto2, ProfileTrainerDTO>(
                    sql,
                    (profile, address) =>
                    {
                        profile.Address = address;
                        return profile;
                    },
                    param,
                    splitOn: "AddressId");

                return result.FirstOrDefault();
            }
        }



        public async Task<bool> UpdateProfile(ProfileTrainerDTO profileTrainerDto)
        {
            var param = new DynamicParameters();
            param.Add("User_ID", profileTrainerDto.Id, DbType.Int32, ParameterDirection.Input);
            param.Add("new_Username", profileTrainerDto.Username, DbType.String, ParameterDirection.Input);
            param.Add("new_Password", profileTrainerDto.Password, DbType.String, ParameterDirection.Input);
            param.Add("new_Fname", profileTrainerDto.Fname, DbType.String, ParameterDirection.Input);
            param.Add("new_Lname", profileTrainerDto.Lname, DbType.String, ParameterDirection.Input);
            param.Add("new_Email", profileTrainerDto.Email, DbType.String, ParameterDirection.Input);
            param.Add("new_ImageName", profileTrainerDto.Imagename, DbType.String, ParameterDirection.Input);
            param.Add("new_Specialization", profileTrainerDto.Specialization, DbType.String, ParameterDirection.Input);
            param.Add("new_Gender", profileTrainerDto.gender, DbType.String, ParameterDirection.Input);
            param.Add("new_Phone", profileTrainerDto.Phone, DbType.Int64, ParameterDirection.Input);
            param.Add("new_Bio_Trainer", profileTrainerDto.Bio_Trainer, DbType.String, ParameterDirection.Input);
            param.Add("new_Longitude", profileTrainerDto.Address?.Longitude, DbType.Double, ParameterDirection.Input);
            param.Add("new_Latitude", profileTrainerDto.Address?.Latitude, DbType.Double, ParameterDirection.Input);
            param.Add("new_City", profileTrainerDto.Address?.City, DbType.String, ParameterDirection.Input);
            param.Add("new_Country", profileTrainerDto.Address?.Country, DbType.String, ParameterDirection.Input);

            using (var connection = _dbContext.Connection)
            {
                var affectedRows = await connection.ExecuteAsync("TRAINER_PACKAGE.UPDATE_PROFILETRAINER", param, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }

        public async Task CompletedCourse(int id)
        {
            var param = new DynamicParameters();
            param.Add("reservation_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("TRAINER_PACKAGE.CompletedCourse", param, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<Reservation>> GetAllReservationT2(int id)
        {
            var param = new DynamicParameters();
            param.Add("TrainerId", id, DbType.Int32, ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Reservation>("Trainer_Package.GetAllReservationT2", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
	}