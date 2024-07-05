using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IRepository
{
    public interface IGUsersRepository
    {
        //Task <Guser> GetUserById(int id);
         Task<StudentInfo> GetStudentById(int id);

        Task<Guser> GetTrainerById(int id);
    }
}
