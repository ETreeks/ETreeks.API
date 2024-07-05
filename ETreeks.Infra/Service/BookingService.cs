using ETreeks.Core.Data;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

      

        public async Task<List<Reservation>> GetAllBookingRequest()
        {
            return await _bookingRepository.GetAllBookingRequest();
        }

        public async Task<List<Reservation>> GetAllPendingBooking()
        {
            return await _bookingRepository.GetAllPendingBooking();
        }

        public async Task<Reservation> GetBookingRequestById(int id)
        {
            return await _bookingRepository.GetBookingRequestById(id);
        }


   
    }
}
