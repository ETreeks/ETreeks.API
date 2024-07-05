using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IRepository
{
    public interface IHomeRepository
    {
        Task<List<Home>> DisplayAllHomes();

        Task<Home> GetHomeById(int id);

        Task<int> UpdateHome(Home home);

        Task<int> CreateHome(Home home);

        Task<int> DeleteHome(int id);
    }
}
