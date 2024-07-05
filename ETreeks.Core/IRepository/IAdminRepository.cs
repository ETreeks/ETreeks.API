﻿using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IRepository
{
    public interface IAdminRepository
    {
        Task<List<Guser>> GetAllPendingTrainer();
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

        Task <List<TotalStudents>> TotalStudentInEachCourse();

        Task<List<TotalCourses>> TotalCoursesInEachCategory();

        Task<List<TotalStdPerTrainer>> TotalStudentsPerTrainer();

        Task<List<TrainerWithStudents>> GetStudentsPerTrainer();

        Task<int> GetCountPendingReservation();


    }
}
