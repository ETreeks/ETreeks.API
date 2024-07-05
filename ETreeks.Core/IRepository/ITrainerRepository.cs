using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IRepository
{
    public interface ITrainerRepository
    {
        List<TrainerSearch> Search(DateTime startDate, DateTime endDate);

        Task AcceptReservationAsync(int reservationId);
        Task RejectReservationAsync(int reservationId);

        Task<List<Reservation>> GetAllPendingReservation();

    }
}
