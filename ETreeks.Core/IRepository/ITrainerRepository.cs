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
        List<TrainerSearch> Search(DateTime startDate, DateTime endDate, int trainerId);
        Task<List<ReservationDate>> GetAllReservationT(int id);
        Task<Reservation> GetReservationByIdAsync(int id);

        Task AcceptReservationAsync(int reservationId);
        Task RejectReservationAsync(int reservationId);

        Task<List<Reservation>> GetAllPendingReservation();

		Task<ProfileTrainerDTO> ViewProfile(int id);
		Task<bool> UpdateProfile(ProfileTrainerDTO profileTrainerDto);


        Task CompletedCourse(int id);
        Task<List<Reservation>> GetAllReservationT2(int id);
    }
}
