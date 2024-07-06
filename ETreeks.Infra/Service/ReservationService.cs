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
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService (IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<int> CreateReservation(Reservation reservation)
        {
            return await _reservationRepository.CreateReservation(reservation);
        }
   

        public async Task DeleteReservation(int id)
        {
            await _reservationRepository.DeleteReservation(id);
        }
   

   
        public async Task<List<Reservation>> GetAllReservations()
        {
            return await _reservationRepository.GetAllReservations();
        }

     
        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationRepository.GetReservationById(id);
        }


        public async Task UpdateReservation(Reservation reservation)
        {
            await _reservationRepository.UpdateReservation(reservation);
        }
     
    }
}
