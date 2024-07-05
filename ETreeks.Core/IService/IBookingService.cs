using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IService
{
    public interface IBookingService
    {
    

        Task<List<Reservation>> GetAllBookingRequest();
        Task<List<Reservation>> GetAllPendingBooking();

        Task<Reservation> GetBookingRequestById(int id);
    }
}
