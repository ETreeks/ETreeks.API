using ETreeks.Core.Data;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
    public class HomeService :IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<int> CreateHome(Home home)
        {
            return await _homeRepository.CreateHome(home);
        }

        public async Task<int> DeleteHome(int id)
        {
            return await _homeRepository.DeleteHome(id);
        }

        public async Task<List<Home>> DisplayAllHomes()
        {
            return await _homeRepository.DisplayAllHomes();
        }

        public async Task<Home> GetHomeById(int id)
        {
            return await _homeRepository.GetHomeById(id);
        }

        public async Task<int> UpdateHome(Home home)
        {
            return await _homeRepository.UpdateHome(home);
        }





     
    }
}
