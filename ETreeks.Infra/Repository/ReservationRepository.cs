using Dapper;

using ETreeks.Core.Data;
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
    public class ReservationRepository : IReservationRepository
    {
        private readonly IDbContext _dbContext;
        public ReservationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateReservation(Reservation reservation)
        {
            var param = new DynamicParameters();
            param.Add("ReservationStatus", reservation.Reservationstatus , DbType.String,direction: ParameterDirection.Input);
            param.Add("ReservationDate", reservation.Reservationdate, DbType.Date, direction: ParameterDirection.Input);
            param.Add("FinalMark", reservation.Finalmark, DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("GUsers_ID", reservation.Gusers_Id, DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("Course_ID", reservation.Course_Id, DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("R_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Reservation_Pkg.CREATE_RESERVATION", param, commandType: CommandType.StoredProcedure);
            int reservationId = param.Get<int>("R_id");
            return reservationId;
        }

        public async Task DeleteReservation(int id)
        {
            var param = new DynamicParameters();
            param.Add("Reservation_ID", id, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Reservation_Pkg.DELETE_RESERVATION", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            var result = await _dbContext.Connection.QueryAsync<Reservation>("Reservation_Pkg.GET_ALL_RESERVATIONS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

   

        public async Task<Reservation> GetReservationById(int id)
        {
            var param = new DynamicParameters();
            param.Add("Reservation_ID", id, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<Reservation>("Reservation_Pkg.GET_RESERVATION_BY_ID", param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Reservation_ID", reservation.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("new_ReservationStatus", reservation.Reservationstatus, DbType.String, ParameterDirection.Input);
            parameters.Add("new_ReservationDate", reservation.Reservationdate, DbType.Date, ParameterDirection.Input);
            parameters.Add("new_FinalMark", reservation.Finalmark, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("new_GUsers_ID", reservation.Gusers_Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("new_Course_ID", reservation.Course_Id, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Reservation_Pkg.UPDATE_RESERVATION", parameters, commandType: CommandType.StoredProcedure);
        }
    }
    }
 

