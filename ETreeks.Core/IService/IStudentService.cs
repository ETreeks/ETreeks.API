using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IService
{
    public interface IStudentService
    {
        Task<int> CreateBookingRequest(Reservation reservation);

        List<SessionDTO> GetTrainerSessionsByUsername(string username);
        List<SessionDTO> GetTrainerSessionsByID(int trainerId);
		Task<ProfileStudentDTO> ViewProfile(int id);
		Task<bool> UpdateProfile(ProfileStudentDTO profileStudentDto);
        //:)
	}
}
