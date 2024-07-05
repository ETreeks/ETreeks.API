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
    public class GUsersService :IGUsersService
    {
        private readonly IGUsersRepository _usersRepository;

        public GUsersService(IGUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<StudentInfo> GetStudentById(int id)
        {
            return _usersRepository.GetStudentById(id);
        }

        public Task<Guser> GetTrainerById(int id)
        {
            return _usersRepository.GetTrainerById(id);
        }

        //public Task<Guser> GetUserById(int id)
        //{
        //    return _usersRepository.GetUserById(id);
        //}

    }
}
