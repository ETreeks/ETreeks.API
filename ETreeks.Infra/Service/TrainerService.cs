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

        public  List<TrainerSearch> Search(DateTime startDate, DateTime endDate ,int trainerId)
        {
            
                return _trainerRepository.Search(startDate, endDate, trainerId);
            
        }
        public async Task<List<ReservationDate>> GetAllReservationT(int id)
        {
            return await _trainerRepository.GetAllReservationT(id);
        }
        public async Task<Reservation> GetReservationByIdAsync(int id)
        { 
            return await _trainerRepository.GetReservationByIdAsync(id);
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

        //public async Task<ProfileTrainerDTO> ViewProfile(int id)
        //{
        //	return await _trainerRepository.ViewProfile(id);
        //}

        //public async Task<bool> UpdateProfile(ProfileTrainerDTO profileTrainerDto)
        //{
        //	return await _trainerRepository.UpdateProfile(profileTrainerDto);
        //}
        public async Task<ProfileTrainerDTO> ViewProfile(int id)
        {
            return await _trainerRepository.ViewProfile(id);
        }
        public async Task<bool> UpdateProfile(ProfileTrainerDTO profileTrainerDto)
        {
            return await _trainerRepository.UpdateProfile(profileTrainerDto);
        }

        public async Task CompletedCourse(int id)
        {
            await _trainerRepository.CompletedCourse(id);
        }
        public async Task<List<Reservation>> GetAllReservationT2(int id)
        {
            return await _trainerRepository.GetAllReservationT2(id);
        }
    }
}
