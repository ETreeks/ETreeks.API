using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository ;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> CreateBookingRequest(Reservation reservation)
        {
            return await _studentRepository.CreateBookingRequest(reservation);
        }
        public List<SessionDTO> GetTrainerSessionsByID(int trainerId)
        {
            return _studentRepository.GetTrainerSessionsByID(trainerId);
        }

        public List<SessionDTO> GetTrainerSessionsByUsername(string username)
        {
            return _studentRepository.GetTrainerSessionsByUsername(username);
        }
		public async Task<ProfileStudentDTO> ViewProfile(int id)
		{
			return await _studentRepository.Viewprofile(id);
		}

		public async Task<bool> UpdateProfile(ProfileStudentDTO profileStudentDto)
		{
			return await _studentRepository.UpdateProfile(profileStudentDto);
		}
	}
}
