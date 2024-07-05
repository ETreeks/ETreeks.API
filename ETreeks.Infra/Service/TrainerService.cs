using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using ETreeks.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
    public class TrainerService :ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public  List<TrainerSearch> Search(DateTime startDate, DateTime endDate)
        {
            
                return _trainerRepository.Search(startDate, endDate);
            
        }
        public async Task AcceptReservationAsync(int reservationId)
        {
            await _trainerRepository.AcceptReservationAsync(reservationId);
        }

        public async Task RejectReservationAsync(int reservationId)
        {
            await _trainerRepository.RejectReservationAsync(reservationId);
        }

        public async Task<List<Reservation>> GetAllPendingReservation()
        {
            return await _trainerRepository.GetAllPendingReservation();
        }
    }
}
