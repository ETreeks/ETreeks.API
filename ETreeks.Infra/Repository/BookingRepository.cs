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
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbContext _dbContext;

        public BookingRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

 

        public async Task<List<Reservation>> GetAllBookingRequest()
        {
            var result = await _dbContext.Connection.QueryAsync<Reservation>("Booking_Package.GetAllBookingRequest", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Reservation>> GetAllPendingBooking()
        {
            var result = await _dbContext.Connection.QueryAsync<Reservation>("Booking_Package.GetAllPendingBooking", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Reservation> GetBookingRequestById(int id)
        {
            var param = new DynamicParameters();
            param.Add("Request_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Reservation>("Booking_Package.GetBookingRequestById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }


        }
}
