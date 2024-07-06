using ETreeks.Core.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IRepository
{
    public interface IReservationRepository
    {

        Task<int> CreateReservation(Reservation reservation);

        Task UpdateReservation(Reservation reservation);

        Task DeleteReservation(int id);

        Task<List<Reservation>> GetAllReservations();


        Task<Reservation> GetReservationById(int id);
    }
}
