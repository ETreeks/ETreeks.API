using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IService
{
    public interface IAdminService
    {
        Task<List<ReservationDate>> GetAllReservation();
		Task<List<PendingTrainerDTO>> GetAllPendingTrainer();

		//Task<List<Guser>> DisplayAllStudents();
		Task<List<StudentInfo>> DisplayAllStudents();
        //Task<StudentInfo> DisplayAllStudents();
        Task<List<Guser>> DisplayAllTrainers();
        Task<List<Guser>> DisplayAllUsers();
        Task<int> GetCountTrainers();
        Task<int> GetCountStudents();
        Task<int> GetCountUsers();

        Task<int> DeleteUser(int id);



        Task<int> GetCountAdmin();
        Task<int> GetCountPendingTrainers();
        Task<int> GetCountAcceptedTrainers();
        Task<int> GetCountCategories();
        Task<int> GetCountCourses();

        Task<List<TotalStudents>> TotalStudentInEachCourse();

        Task<List<TotalCourses>> TotalCoursesInEachCategory();

        Task<List<TotalStdPerTrainer>> TotalStudentsPerTrainer();

        Task<List<TrainerWithStudents>> GetStudentsPerTrainer();

        Task<int> GetCountPendingReservation();
        Task<int> GetCountAcceptedReservation();
        Task AcceptProfileAdmin(int userId, string newRegistrationStatus);
        Task<Guser> GetProfileAdmin(int userId);
        Task UpdateProfileAdmin(UpdateProfileAdminDto updateProfileAdminDto);
		Task<string> GetTrainerEmail(int Trainer_ID);


		Task AccepttesTimonial(int id);
        Task AccepttesCourse(int id);
		Task<int> ApproveTrainer(int trainerId);
		Task<int> RemoveTrainer(int trainerId);
		List<Guser> SearchTrainerByName(string trainerName);
		Task SendApprovalEmail(string email);

	}
}
