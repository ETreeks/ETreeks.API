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

	public class AboutService : IAboutService
	{
		private readonly IAboutRepository _aboutRepository;

		public AboutService(IAboutRepository aboutRepository)
		{
			_aboutRepository = aboutRepository;
		}

		public async Task<int> CreateAbout(About about)
		{
			return await _aboutRepository.CreateAbout(about);
		}

		public async Task<int> UpdateAbout(About about)
		{
			return await _aboutRepository.UpdateAbout(about);
		}

		public async Task<int> DeleteAbout(int id)
		{
			return await _aboutRepository.DeleteAbout(id);
		}

		public async Task<List<About>> GetAllAbout()
		{
			return await _aboutRepository.GetAllAbout();
		}

		public async Task<About> GetAboutById(int id)
		{
			return await _aboutRepository.GetAboutById(id);
		}
	}
}
