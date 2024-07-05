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
    public class TrainerRepository :ITrainerRepository
    { 
        private readonly IDbContext _dbContext;

        public TrainerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<TrainerSearch> Search(DateTime startDate, DateTime endDate)
        {
            var p = new DynamicParameters();
            p.Add("DateFrom", startDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DateTo", endDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<TrainerSearch>("Trainer_Package.GetReservationsInfoByInterval", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task AcceptReservationAsync(int reservationId)
        {
            var param = new DynamicParameters();
            param.Add("reservation_id", reservationId, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Reservation_Package.AcceptReservation", param, commandType: CommandType.StoredProcedure);
        }


        public async Task RejectReservationAsync(int reservationId)
        {
            var param = new DynamicParameters();
            param.Add("reservation_id", reservationId, DbType.Int32, ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Reservation_Package.RejectReservation", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Reservation>> GetAllPendingReservation()
        {
            var result = await _dbContext.Connection.QueryAsync<Reservation>("Trainer_Package.GetAllPendingReservation", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
