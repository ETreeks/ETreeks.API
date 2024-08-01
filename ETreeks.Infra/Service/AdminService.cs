using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using ETreeks.Infra.Repository;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<List<ReservationDate>> GetAllReservation()
        {
            return await _adminRepository.GetAllReservation();
        }
        public async Task<int> DeleteUser(int id)
        {
            return await _adminRepository.DeleteUser(id);
        }

        public async Task<List<StudentInfo>> DisplayAllStudents()
        {
            return await _adminRepository.DisplayAllStudents();
        }
        public async Task<List<Guser>> DisplayAllTrainers()
        {
            return await _adminRepository.DisplayAllTrainers();
        }

        public async Task<List<Guser>> DisplayAllUsers()
        {

            return await _adminRepository.DisplayAllUsers();
        }

        public async Task<List<Guser>> GetAllPendingTrainer()
        {
            return await _adminRepository.GetAllPendingTrainer();
        }

        public async Task<int> GetCountAcceptedTrainers()
        {
            return await _adminRepository.GetCountAcceptedTrainers();
        }

        public async Task<int> GetCountAdmin()
        {
            return await _adminRepository.GetCountAdmin();
        }

        public async Task<int> GetCountCategories()
        {
            return await _adminRepository.GetCountCategories(); ;
        }

        public async Task<int> GetCountCourses()
        {
            return await _adminRepository.GetCountCourses();
        }

        public async Task<int> GetCountPendingTrainers()
        {
            return await _adminRepository.GetCountPendingTrainers();
        }

        public async Task<int> GetCountStudents()
        {
            return await _adminRepository.GetCountStudents();
        }

        public async Task<int> GetCountTrainers()
        {
            return await _adminRepository.GetCountTrainers();
        }

        public async Task<int> GetCountUsers()
        {
            return await _adminRepository.GetCountUsers();
        }

    

        public async Task<List<TotalCourses>> TotalCoursesInEachCategory()
        {
            return await _adminRepository.TotalCoursesInEachCategory();
        }

        public async Task<List<TotalStudents>> TotalStudentInEachCourse()
        {
            return await _adminRepository.TotalStudentInEachCourse();
        }

        public async Task<List<TotalStdPerTrainer>> TotalStudentsPerTrainer()
        {
            return await _adminRepository.TotalStudentsPerTrainer();
        }
        //public async Task<List<GetStdPerTrainer>> GetStudentsPerTrainer()
        //{
        //    return await _adminRepository.GetStudentsPerTrainer();
        //}
        public async Task<List<TrainerWithStudents>> GetStudentsPerTrainer()
        {
            var trainersWithStudents = await _adminRepository.GetStudentsPerTrainer();

            var groupedResult = from trainer in trainersWithStudents
                                group trainer by new { trainer.TrainerId, trainer.TrainerUsername } into g
                                select new TrainerWithStudents
                                {
                                    TrainerId = g.Key.TrainerId,
                                    TrainerUsername = g.Key.TrainerUsername,
                                    Students = g.SelectMany(t => t.Students).ToList()
                                };

            return groupedResult.ToList();
        }

        public async Task<int> GetCountPendingReservation()
        {
            return await _adminRepository.GetCountPendingReservation();
        }

        public async Task AcceptProfileAdmin(int userId, string newRegistrationStatus)
        {
            await _adminRepository.AcceptProfileAdmin(userId, newRegistrationStatus);
        }

        public async Task<Guser> GetProfileAdmin(int userId)
        {
            return await _adminRepository.GetProfileAdmin(userId);
        }



        public async Task UpdateProfileAdmin(UpdateProfileAdminDto updateProfileAdminDto)
        {
            await _adminRepository.UpdateProfileAdmin(updateProfileAdminDto);
        }

        public async Task<int> GetCountAcceptedReservation()
        {
            return await _adminRepository.GetCountAcceptedReservation();
        }

        public async Task AccepttesTimonial(int id)
        {
            await _adminRepository.AccepttesTimonial(id);
        }

        public async Task AccepttesCourse(int id)
        {
            await _adminRepository.AccepttesCourse(id);
        }
    }
}
